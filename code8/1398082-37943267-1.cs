            string source = @"D:\MyFile.txt";
            string destination = @"D:\MyFile2.txt";
            int columnToChange = 3;
            string newValueForColumn = "High";
            using (FileStream sourceStream = new FileStream(source, FileMode.Open))
            {
                using (FileStream destinationStream = new FileStream(destination, FileMode.CreateNew))
                {
                    using (StreamReader sourceReader = new StreamReader(sourceStream))
                    {
                        using (StreamWriter destinationWriter = new StreamWriter(destinationStream))
                        {
                            string oldLine = string.Empty;
                            while ((oldLine = sourceReader.ReadLine()) != null)
                            {
                                string[] values = oldLine.Split('\t');
                                StringBuilder newLine = new StringBuilder();
                                if (values.Length > columnToChange)
                                {
                                    values[columnToChange] = newValueForColumn;
                                    for (int i = 0; i < values.Length; i++)
                                    {
                                        newLine.Append(values[i]);
                                        if (i + 1 < values.Length)
                                        {
                                            newLine.Append('\t');
                                        }
                                    }
                                }
                                else
                                {
                                    newLine.Append(oldLine);
                                }
                                destinationWriter.WriteLine(newLine.ToString());
                            }
                        }
                    }
                }
            }
            // File.Delete(source);
            File.Move(source, source + ".bak");
            File.Move(destination, source);
        }
