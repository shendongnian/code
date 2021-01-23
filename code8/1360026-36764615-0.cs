    /// <summary>
    /// Impersonation - Creates new instance of TfsTeamProjectCollection object using a different user;
    /// </summary>
    /// <param name="serverUri">Tfs server uri you want to connect using Impersonation</param>
    /// <param name="userToImpersonate">Account name of the user you want to Impersonate</param>
    private void Impersonation(Uri serverUri, string userToImpersonate)
    {
        try
        {
            eventLog1.WriteEntry("Start Impersonation");
            // Read out the identity of the user we want to impersonate
            TeamFoundationIdentity identity = ims.ReadIdentity(IdentitySearchFactor.AccountName,
                userToImpersonate,
                MembershipQuery.None,
                ReadIdentityOptions.None);
            eventLog1.WriteEntry(identity.DisplayName);
            this.impersonatedTFSUser = new TfsTeamProjectCollection(serverUri, identity.Descriptor);
            eventLog1.WriteEntry(impersonatedTFSUser.Name);
            eventLog1.WriteEntry("End Impersonation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
