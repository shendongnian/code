      public void Fileprocessing(directories){
                 foreach (string d in directories)
                                {
                    foreach (string f in Directory.GetFiles(d))
                                        {
                                        Console.WriteLine(f);
                                            File.Copy(f,"");
                                        }
                }
                    if(conditionToAddPath){
                    directories.Add("another path");
                    Fileprocessing(directories);
                    }
        }
