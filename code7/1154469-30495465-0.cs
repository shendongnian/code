    [TestMethod]
        async public Task FtpTestUser1()
        {
            var client = new FtpClient
            {
                Host = "127.0.0.1",
                Port = 21,
                Encoding = System.Text.Encoding.Default,
                Credentials = new NetworkCredential
                {
                    // Storing username, password and default directory in a .dat file
                    UserName = "123", 
                    Password = "123",
                },
                DataConnectionType = FtpDataConnectionType.AutoActive // Changed this part.
            };
            await client.ConnectAsync();
            Debug.WriteLine("Connected");
            var path = @"Test"; // This path is now relative to the default directory
            client.SetWorkingDirectory(path);
            Debug.WriteLine(client.GetWorkingDirectory());
           
            var items = client.GetListing();
            Assert.IsTrue(items.Any());
            Debug.WriteLine(items.Count());
            foreach (var ftpListItem in items)
            {
                Debug.WriteLine(string.Format("File name is {0}", ftpListItem.Name));
            }        
        }
