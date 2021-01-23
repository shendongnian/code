    class Program
    {
        public static Image cnvrtToImg(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        static void Main(string[] args)
        {
            using (var file = File.Open(@"D:\0.jpg", FileMode.Open))
            {
                var buffer = new byte[file.Length];
                file.Read(buffer, 0, (int) file.Length);
                cnvrtToImg(buffer);
            }
        }
    }
    
    //finish
