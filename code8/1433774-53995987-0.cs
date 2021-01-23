    Stream content = Console.OpenStandardInput();
    
                    using (BinaryReader standardInputReader = new BinaryReader(content))
                    {
                        using (FileStream standardInputFile = new FileStream(standardInputFilename, FileMode.Create, FileAccess.ReadWrite))
                        {
                            standardInputReader.BaseStream.CopyTo(standardInputFile);
                         }
    
                       
                    }
