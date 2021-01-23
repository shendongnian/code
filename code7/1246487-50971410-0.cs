    String collectionUri = "https://{account}.visualstudio.com";
                    VssCredentials creds = new VssClientCredentials();
                    creds.Storage = new VssClientCredentialStorage();
                    VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
                    var licensingHttpClient = connection.GetClient<LicensingHttpClient>();
                    var accountEntitlement = licensingHttpClient.GetAccountEntitlementAsync().Result;
                    var license = accountEntitlement.License;
