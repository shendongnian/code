      using (var client = new ImapClient())
            {
                try
                {
                    client.Connect(ConfigurationManager.AppSettings["ImapServer"], int.Parse(ConfigurationManager.AppSettings["ImapPort"]), SecureSocketOptions.Auto);
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // MailKit uses by default ntlm authentication
                    client.Authenticate("username", "password");
                   
                    var draftFolder = client.GetFolder(SpecialFolder.Drafts);
                    if (draftFolder != null)
                    {
                        draftFolder.Open(FolderAccess.ReadWrite);
                        draftFolder.Append(message, MessageFlags.Draft);
                       draftFolder.Expunge();
                    }
                    else
                    {
                        var toplevel = client.GetFolder(client.PersonalNamespaces[0]);
                        var DraftFolder = toplevel.Create(SpecialFolder.Drafts.ToString(), true);
                        DraftFolder.Open(FolderAccess.ReadWrite);
                        DraftFolder.Append(message, MessageFlags.Draft);
                        DraftFolder.Expunge();
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("IMAPException has occured: " + ex.Message);
                }
                client.Disconnect(true);
            }
