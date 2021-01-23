                    var fileDescriptor = (MemoryStream)Clipboard.GetDataObject().GetData("FileGroupDescriptorW");
                    var files = FileDescriptorReader.Read(fileDescriptor);
                        foreach (var fileContentFile in files)
                        {
                            if ((fileContentFile.FileAttributes & FileAttributes.Directory) != 0)
                            {
                                //Do something with directories?
                                //Note that directories do not have FileContents
                                //And will throw if we try to read them
                            }
                            else
                            {
                                var fileData = ClipboardHelper.GetFileContents(Clipboard.GetDataObject(), i);
                                fileData.Position = 0;
                                //Do something with the fileContent Stream
                            }
                            i++;                            
                        }
