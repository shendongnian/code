     List<string> directories = new List<string>(Directory.GetDirectories(driveName));
                        string name=null;
    
                        foreach(string directry in directories)
                        {
                            if (GetFileInformation(directry, out name))
                            {
                                try
                                {
                                    DirSearch(directry, fileName, ref  foundVar);         
                                }
                                catch (System.Exception excpt)
                                {
                                    Console.WriteLine("from except msg :" + excpt.Message);
                                    if(foundVar==true)
                                    {                                    
                                        break;
                                    }
                                }
                            }
                        }  
