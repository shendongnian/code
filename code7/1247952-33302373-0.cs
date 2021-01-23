    public static bool CheckIfSignatureAlreadySignedByUser(SPSite site, SPWeb web, int RowID)
        {
            RevertToAppPool revert = new RevertToAppPool();
            try
            {
                revert.UseAppPoolIdentity();
                string dbConnectionString = site.WebApplication.Properties["dbConnection"].ToString();
                using (dbDWDataContext dataContext = new dbDWDataContext(dbConnectionString))
                {
                    var signatures = dataContext.CM_Signatures.Where(c => c.ParagraphID == RowID).ToList();
                    if (signatures != null && signatures.Any())
                    {
                        foreach (var sig in signatures)
                        {
                            if (sig.LoginName.ToLower() == web.CurrentUser.LoginName.ToLower())
                            {
                                return false;
                            }
                            else
                                return true;
                        }
                    }
                    return true;                    
                }
            }
            catch (Exception error)
            {
                SEPUtilities.WriteErrorToLog("Error in DWUtilities.AddSignature: {0}", error.ToString());
                return false;
            }
            finally
            {
                revert.ReturnToImpersonatingCurrentUser();
            }
        }
