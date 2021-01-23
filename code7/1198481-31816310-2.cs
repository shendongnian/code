        //Adding values to the stored procedure
                    Console.WriteLine("Please enter project title and press Enter");
                    string projectTitle = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(projectTitle))
                    {
                        Console.WriteLine("Please enter project title and press Enter");
                        projectTitle = Console.ReadLine();
                    }
                    string outCsvFile = string.Format(@"D:\\test\\{0}.csv", projectTitle);
                    if (System.IO.File.Exists(outCsvFile))
                    {
                        throw new ApplicationException("File already exist Name " + outCsvFile);
                    }
                    sqlCmd.Parameters.AddWithValue("@ProjectTitle", projectTitle); //this value I would like to add it when the console application is executed when I will hit on enter.
                    
                        
