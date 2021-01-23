        public async Task<string> Token(Microsoft.AspNetCore.Hosting.IWebHostEnvironment webenv)
        {
                var root = webenv.ContentRootPath;
                var file = System.IO.Path.Combine(root, "googleanalytics.json");
                Google.Apis.Auth.OAuth2.GoogleCredential credential = GoogleCredential.FromFile(file);
                credential = credential.CreateScoped(new[] {"https://www.googleapis.com/auth/analytics.readonly" });
                var result = await ((ITokenAccess)credential).GetAccessTokenForRequestAsync();
                return result;
        }
