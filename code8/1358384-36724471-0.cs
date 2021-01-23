    managerApp.UseIdentityManager(new IdentityManagerOptions()
                    {                            
                        SecurityConfiguration = new HostSecurityConfiguration
                        {
                            HostAuthenticationType = "cookies",
                            AdditionalSignOutType = "oidc",
                            NameClaimType = Constants.ClaimTypes.Name,
                            RoleClaimType = Constants.ClaimTypes.Role,
                            AdminRoleName = "IdentityManagerAdministrator" //default role name for IdentityManager
                        }
                    });
