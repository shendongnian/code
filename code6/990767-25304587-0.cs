            var initializer = new ServiceAccountCredential.Initializer(ServiceAccountId)
            {
                Scopes = scope,
                User = AdminEmail1
            };
            var credential = new ServiceAccountCredential(initializer.FromCertificate(certificate));
            var driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
