    using System;
    using System.IO;
    using System.Text;
    
    namespace ResourceTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create a memory stream to read the file into..
                MemoryStream outStream = new MemoryStream();
                //Copy our _out.wav File
                SomeResource._out.CopyTo(outStream);
                //Also possible: 
                //SomeResource.ResourceManager.GetStream("out.wav")...
                //Read into a byte array.
                byte[] file_bytes = outStream.ToArray();
                //Close it
                outStream.Close();
    
                //Do something with file_bytes..
            }
        }
    }
