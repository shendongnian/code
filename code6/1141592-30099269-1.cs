                    Int32 endOfLineCharacterCount = 0;
                    Int32 previousCharByte = 0;
                    Int32 currentCharByte = 0;
                    //Read the file, from the end, for 1 line, allowing other programmes to access it for read and write!
                    using (FileStream reader = new FileStream(fullFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
                    {
                        int i = 0;
                        StringBuilder lineBuffer = new StringBuilder();
                        int byteRead;
                        while ((-i < reader.Length) /*Belt and braces: if there were no end of line characters, reading beyond the file would give a catastrophic error here (to be avoided thus).*/
                            && (endOfLineCharacterCount < 2)/*Exit Condition*/)
                        {
                            reader.Seek(--i, SeekOrigin.End);
                            byteRead = reader.ReadByte();
                            currentCharByte = byteRead;
                            //Exit condition: the first 2 characters we read (reading backwards remember) were end of line (). 
                            //So when we read the second end of line, we have read 1 whole line (the last line in the file)
                            //and we must exit now.
                            if (currentCharByte == 13 && previousCharByte == 10)
                            {
                                endOfLineCharacterCount++;
                            }
                            if (byteRead == 10 && lineBuffer.Length > 0)
                            {
                                line += Reverse(lineBuffer.ToString());
                                lineBuffer.Remove(0, lineBuffer.Length);
                            }
                            lineBuffer.Append((char)byteRead);
                            previousCharByte = byteRead;
                        }
                        reader.Close();
                    }
