     Console.WriteLine("Please enter project title and press Enter");
                        string projectTitle = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(projectTitle))
                        {
                            throw new ApplicationException("Project title is null or empty");
                        }
                        sqlCmd.Parameters.AddWithValue("@ProjectTitle", projectTitle); //this value I would like to add it when the console application is executed when I will hit on enter.
                        
