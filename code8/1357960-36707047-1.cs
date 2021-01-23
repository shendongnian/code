    using System;
    using System.Text;
    using System.IO;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                using (BinaryWriter writer = new BinaryWriter(File.Open("TextFile1.txt", FileMode.Open, FileAccess.ReadWrite)))
                {
                    int offset = 1; //position you want to start editing
                    byte[] new_data = new byte[] { 0x68, 0x69 }; //new data
                    writer.Seek(offset, SeekOrigin.Begin); //move your cursor to the position
                    writer.Write(new_data);//write it      
                }
            }
        }
    }
