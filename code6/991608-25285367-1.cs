                public static byte[] GetFile(string fileID, out string contenttype, out string filename)
        {
            DALParameter dalp = new DALParameter();
            var gdEmail = dalp.GetParameter(INMDTO.Parameters.GoogleDriveLogin, INMDTO.ParametersLevel.General, 0);
            var credential = GetCertificate();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "tttt",
            });
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\";
            string certFile = "gd.p12";
            string fullcertpath = Path.Combine(path, certFile);
            var email = gdEmail;
            var auth = GoogleJsonWebToken.GetAccessToken(email, fullcertpath, GoogleJsonWebToken.SCOPE_DRIVE_READONLY);
            var f = service.Files.Get(fileID).Execute();
            contenttype = f.MimeType;
            filename = f.OriginalFilename;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(f.DownloadUrl));
            req.Headers.Add("Authorization", auth["token_type"] + " " + auth["access_token"]);
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream sourceStream = response.GetResponseStream(); // the ConnectStream
                byte[] array;
                using (var ms = new MemoryStream())
                {
                    sourceStream.CopyTo(ms);
                    array = ms.ToArray();
                }
                return array;
            }
            return null;
        }
