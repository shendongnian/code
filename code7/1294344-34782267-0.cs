    var appname = "Test Application create " + DateTime.Now.Ticks;
    var application = new Application()
            {
                AvailableToOtherTenants = false,
                DisplayName = appname,
                ErrorUrl = null,
                GroupMembershipClaims = null,
                Homepage = "http://www.domain.com",
                IdentifierUris = new List<string>() {{"https://domain.com/"+ "Test" } },// CHANGED LINE
                KeyCredentials = new List<KeyCredential>(),
                KnownClientApplications = new List<Guid>(),
                LogoutUrl = null,
                Oauth2AllowImplicitFlow = false,
                Oauth2AllowUrlPathMatching = false,
                Oauth2Permissions = new List<OAuth2Permission>()
                {
                    {
                        new OAuth2Permission()
                        {
                            AdminConsentDescription =
                                $"Allow the application to access {appname} on behalf of the signed-in user.",
                            AdminConsentDisplayName = $"Access {appname}",
                            Id = Guid.NewGuid(),
                            IsEnabled = true,
                            Type = "User",
                            UserConsentDescription =
                                $"Allow the application to access {appname} on your behalf.",
                            UserConsentDisplayName = $"Access {appname}",
                            Value = "custom_scope" // CHANGED LINE
                        }
                    }
                },
                Oauth2RequirePostResponse = false,
                PasswordCredentials = new List<PasswordCredential>(),
                PublicClient = false,
                ReplyUrls = new List<string>(),
                RequiredResourceAccess = new List<RequiredResourceAccess>(),
                SamlMetadataUrl = null,
                ExtensionProperties = new List<ExtensionProperty>(),
                Manager = null,
                ObjectType = "Application",
                DeletionTimestamp = null,
                CreatedOnBehalfOf = null,
                CreatedObjects = new List<DirectoryObject>(),
                DirectReports = new List<DirectoryObject>(),
                Members = new List<DirectoryObject>(),
                MemberOf = new List<DirectoryObject>(),
                Owners = new List<DirectoryObject>(),
                OwnedObjects = new List<DirectoryObject>()
      };
    await client.Applications.AddApplicationAsync(application);
