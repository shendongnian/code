        public DriveService GetService(string certificatePath, string certificatePassword, string googleAppsEmailAccount, string emailAccountToMimic, bool allowWrite = true)
        {
            var certificate = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(googleAppsEmailAccount)
               {
                   Scopes = new[] { allowWrite ? DriveService.Scope.Drive : DriveService.Scope.DriveReadonly },
                   User = emailAccountToMimic
               }.FromCertificate(certificate));
            // Create the service.
            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
