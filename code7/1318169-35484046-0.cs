    using (Stream input = thisAssembly.GetManifestResourceStream("Namespace.EmbeddedResources.MyApplication.exe")) 
                {
    
                    byte[] byteData = StreamToBytes(input); 
                }
            /// <summary>
            /// StreamToBytes - Converts a Stream to a byte array. Eg: Get a Stream from a file,url, or open file handle.
            /// </summary>
            /// <param name="input">input is the stream we are to return as a byte array</param>
            /// <returns>byte[] The Array of bytes that represents the contents of the stream</returns>
            static byte[] StreamToBytes(Stream input)
            {
    
                int capacity = input.CanSeek ? (int)input.Length : 0; //Bitwise operator - If can seek, Capacity becomes Length, else becomes 0.
                using (MemoryStream output = new MemoryStream(capacity)) //Using the MemoryStream output, with the given capacity.
                {
                    int readLength;
                    byte[] buffer = new byte[capacity/*4096*/];  //An array of bytes
                    do
                    {
                        readLength = input.Read(buffer, 0, buffer.Length);   //Read the memory data, into the buffer
                        output.Write(buffer, 0, readLength); //Write the buffer to the output MemoryStream incrementally.
                    }
                    while (readLength != 0); //Do all this while the readLength is not 0
                    return output.ToArray();  //When finished, return the finished MemoryStream object as an array.
                }
    
            }
