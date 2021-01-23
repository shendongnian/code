    using (StreamReader reader = new StreamReader(await selectedFile.OpenStreamForReadAsync()))
                {
                    while ((nextLine = await reader.ReadLineAsync()) != null)
                    {
                        contents.AppendFormat("{0}. ", lineCounter);
                        contents.Append(nextLine);
                        contents.AppendLine();
                        lineCounter++;
                        if (lineCounter > 3)
                        {
                            contents.AppendLine("Only first 3 lines shown.");
                            break;
                        }
                    }
                }
