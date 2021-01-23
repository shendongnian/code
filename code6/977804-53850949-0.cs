                var optConfig = new Options
                {
                    ClientId = "0000000000000000",
                    ClientSecret = "XXXXt02UYkQm6Kb48fKtD7",
                    CallbackUrl = "https://login.live.com/oauth20_desktop.srf",
                    AutoRefreshTokens = true,
                    PrettyJson = false,
                    AccessToken = "AccessTokenXXXXX",
                    RefreshToken = "RefreshTokenXXXX",
                    ReadRequestsPerSecond = 2,
                    WriteRequestsPerSecond = 2
                };
                var client = new Client(optConfig);
                var rootFolder = await client.GetFolderAsync();
                // rootFolder.Name - folder name
                //rootFolder.Id  - folder id
                var folderContent = await client.GetContentsAsync(rootFolder.Id);
                foreach (var item in folderContent)
                {
                    Console.WriteLine("\tItem ({0}: {1} (Id: {2})", item.Type, item.Name, item.Id);
                    var folderContent = await client.GetContentsAsync(item.Id);
                    var filesList = folderContent.Where(e => e.Type != "folder");
                                    foreach (var fileItem in filesList)
                                    {
									   //Download files here
										var uri = fileItem.Source;
										var request = (HttpWebRequest)WebRequest.Create(uri);
										HttpWebResponse response;
										response = (HttpWebResponse)request.GetResponse();										
										if ((response.StatusCode == HttpStatusCode.OK ||
											 response.StatusCode == HttpStatusCode.Moved ||
											 response.StatusCode == HttpStatusCode.Redirect))
										{
											var tempFileName = response.ResponseUri.Segments[(response.ResponseUri.Segments.Count() - 1)];
											using (var fileStream = response.GetResponseStream())
											{
											//Save Strame	
											}
										}
                                       
                                    }
				}
