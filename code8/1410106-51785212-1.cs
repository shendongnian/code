        public static IEnumerable<string> ReadLinesCrLf(this TextReader reader, int bufferSize = 4096)
        {
            StringBuilder lineBuffer = null;
            //read buffer            
            char[] buffer = new char[bufferSize];
            int charsRead;
            var previousIsLf = false;
            while ((charsRead = reader.Read(buffer, 0, bufferSize)) != 0)
            {
                int bufferIndex = 0;
                int writeIdx = 0;
                do
                {
                    var currentChar = buffer[bufferIndex];
                    switch (currentChar)
                    {
                        case '\n':
                            if (previousIsLf)
                            {
                                if (lineBuffer == null)
                                {
                                    //return from current buffer writeIdx could be higher than 0 when multiple rows are in the buffer                                            
                                    yield return new string(buffer, writeIdx, bufferIndex - writeIdx - 1);
                                    //shift write index to next character that will be read
                                    writeIdx = bufferIndex + 1;
                                }
                                else
                                {
                                    Debug.Assert(writeIdx == 0, $"Write index should be 0, when linebuffer != null");
                                    lineBuffer.Append(buffer, writeIdx, bufferIndex - writeIdx);
                                    Debug.Assert(lineBuffer.ToString().Last() == '\r',$"Last character in linebuffer should be a carriage return now");
                                    lineBuffer.Length--;
                                    //shift write index to next character that will be read
                                    writeIdx = bufferIndex + 1;
                                    yield return lineBuffer.ToString();
                                    lineBuffer = null;
                                }
                            }
                            previousIsLf = false;
                            break;
                        case '\r':
                            previousIsLf = true;
                            break;
                        default:
                            previousIsLf = false;
                            break;
                    }
                    bufferIndex++;
                } while (bufferIndex < charsRead);
                if (writeIdx < bufferIndex)
                {
                    if (lineBuffer == null) lineBuffer = new StringBuilder();
                    lineBuffer.Append(buffer, writeIdx, bufferIndex - writeIdx);
                }
            }
            //return last row
            if (lineBuffer != null && lineBuffer.Length > 0) yield return lineBuffer.ToString();
        }
