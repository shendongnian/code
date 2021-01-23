    public ServiceResponse ChangePassword(string username, string oldPassword, string newPassword)
            {
                ServiceResponse response = new ServiceResponse();
    
                try
                {
                    var entry = new DirectoryEntry(DomainUsersConnectionString, username, oldPassword);
                    var nativeObject = entry.NativeObject;
    
                    // Check passed. Can reset the password now
                    entry = RootDirectoryEntry;
                    var user = FindUserInDirectoryEntry(username, entry);
                    response = SetPassword(user, newPassword);
                    user.Close();
                }
                catch (DirectoryServicesCOMException ex)
                {
                    response.Status = Status.Error;
                    response.Message = ex.ExtendedErrorMessage;
                    m_Logger.Error("Failed to change password for user {0}: {1} - {2}", username, ex.ExtendedErrorMessage, (ex.InnerException ?? ex));
                }
                catch (Exception ex)
                {
                    response.Status = Status.Error;
                    response.Message = ex.Message;
                    m_Logger.Error("Failed to change password for user {0}: {1} -{2}", username, ex.Message, (ex.InnerException ?? ex));
                }
                return response;
            }
    
    
    
            /// <summary>
            /// Finds the user in directory entry.
            /// </summary>
            /// <param name="username">The username.</param>
            /// <param name="dirEntry">The dir entry.</param>
            /// <returns></returns>
            protected static DirectoryEntry FindUserInDirectoryEntry(string username, DirectoryEntry dirEntry)
            {
                // rip off Domain name if username contains it
                string domainName = String.Format(@"{0}\", DomainName).ToLowerInvariant();
                username = username.Replace(domainName, "");
                DirectorySearcher searcher = new DirectorySearcher(dirEntry)
                {
                    Filter = String.Format("(samAccountName={0})", username)
                };
                var searchResult = searcher.FindOne();
                if (searchResult != null)
                {
                    DirectoryEntry user = searchResult.GetDirectoryEntry();
                    return user;
                }
                return null;
            }
    
    
    
            private ServiceResponse SetPassword(DirectoryEntry user, string password)
            {
                ServiceResponse response = new ServiceResponse();
    
                try
                {
                    using (var impersonator = new Impersonator(DomainAdminUsername, DomainName, DomainAdminPassword))
                    {
                        user.Invoke("SetPassword", new object[] { password });
                        user.Properties["LockOutTime"].Value = 0; //unlock account
                        user.CommitChanges();
                    }
                    response.Status = Status.Success;
                }
                catch (DirectoryServicesCOMException ex)
                {
                    response.Status = Status.Error;
                    response.Message = ex.ExtendedErrorMessage;
                    m_Logger.Error("SetPassword failed for user {0}: {1}", user.Name, ex.ExtendedErrorMessage);
                }
                catch (Exception ex)
                {
                    response.Status = Status.Error;
                    response.Message = ex.Message;
                    m_Logger.Error("SetPassword failed for user {0} by {1} at {2}: {3}: {4}", user.Name, 
                        DomainAdminUsername, DomainName,
                        ex.Message, (ex.InnerException ?? ex).ToString());
                }
    
                return response;
            }
