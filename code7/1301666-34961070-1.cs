        static void DoSheet()
        {
            var certificate = new X509Certificate2(@"cert.p12", "notasecret", X509KeyStorageFlags.Exportable);
            const string scope = "https://spreadsheets.google.com/feeds https://docs.google.com/feeds";
            var credential = new
            ServiceAccountCredential(
                new ServiceAccountCredential.Initializer("project email")
                {
                    Scopes = new[] { scope }
                }.FromCertificate(certificate));
            var requestFactory = new GDataRequestFactory("App name");
            bool success = credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Result;
            requestFactory.CustomHeaders.Add($"Authorization: Bearer {credential.Token.AccessToken}");
            var service = new SpreadsheetsService("prfproject-1198") {RequestFactory = requestFactory};
            var path = $"https://spreadsheets.google.com/feeds/worksheets/1oKSViNtjtaKjdckJBiIQEZHgbUImnmiNOCQsYpIGdl0/private/full";
            var query = new WorksheetQuery(path);
            var feed = service.Query(query);
            var worksheet = (WorksheetEntry)feed.Entries[0];
            var cellQuery = new CellQuery(worksheet.CellFeedLink);
            var cellFeed = service.Query(cellQuery);
            // Iterate through each cell, printing its value.
            foreach (var atomEntry in cellFeed.Entries)
            {
                var cell = (CellEntry) atomEntry;
                if (cell.Title.Text == "A1")
                {
                    cell.InputValue = "200";
                    cell.Update();
                }
                else if (cell.Title.Text == "B1")
                {
                    cell.InputValue = "=SUM(A1, 200)";
                    cell.Update();
                }
            }
        }
