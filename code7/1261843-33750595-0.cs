                using (var documentClient = new DocumentClient(new Uri("<endpoint>"), "<accountkey>"))
                {
                    var listDatabasesOperationResult = await documentClient.ReadDatabaseFeedAsync();
                    foreach (var item in listDatabasesOperationResult)
                    {
                        Console.WriteLine(item.Id);
                    }
                }
