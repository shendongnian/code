                        if (line.StartsWith(folderTag))
                        {
                            line = line.Substring(folderTag.Length); // remove the folderTag from the beginning
                            Folders.AddRange(line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                        }
                        else if(line.StartsWith("parameters="))
                        {
                            // do something different with a line starting with "parameters="
                        }
                        else if (line.StartsWith("unicorns="))
                        {
                            // do something else different with a line starting with "unicorns="
                        }
