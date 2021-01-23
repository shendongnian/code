    static byte[] StreamToBytes(Stream input)
                {
    
                    int capacity = input.CanSeek ? (int)input.Length : 0; 
                    using (MemoryStream output = new MemoryStream(capacity))
                    {
                        int readLength;
                        byte[] buffer = new byte[capacity/*4096*/];  //An array of bytes
                        do
                        {
                            readLength = input.Read(buffer, 0, buffer.Length);   //Read the memory data, into the buffer
                            output.Write(buffer, 0, readLength);
                        }
                        while (readLength != 0); //Do all this while the readLength is not 0
                        return output.ToArray();  //When finished, return the finished MemoryStream object as an array.
                    }
    
                }
    
    
    
    Assembly yourAssembly = Assembly.GetAssembly(typeof(MyTypeWithinAssembly));
    using (Stream input = yourAssembly.GetManifestResourceStream("NameSpace.Resources.Config.json")) // Acquire the dll from local memory/resources.
                    {
                        byte[] byteData  = StreamToBytes(input);
    					System.IO.File.WriteAllBytes(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)+"//Config.json",new byte[]{});
                    }
    				
    var builder = new ConfigurationBuilder()
        .AddJsonFile(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)+"//Config.json");
