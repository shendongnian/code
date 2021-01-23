                       string fileName = Path.GetFileName(yourFullPath);
                       string sourceDirectory = yourFullPath.Replace(fileName,"");
                       string pattern = "aa*.xml";
        
                        try
                        {
                            var foundFiles = Directory.EnumerateFiles(sourceDirectory, pattern);
            
                            foreach (string currentFile in foundFiles)
                            {
                              //Do whatever you need here...
                            }
                        }
                        catch (Exception e)
                        {
                            //.....
                        }
