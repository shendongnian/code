    class Program
    {
        static void Main(string[] args)
        {
            Bitmap b = Bitmap.FromFile(Path.Combine(Environment.CurrentDirectory, "test.bmp")) as Bitmap;
            Bitmap b2 = b.Clone() as Bitmap;
    
            Console.WriteLine("Height: original: {0}, clone: {1}",b.Size.Height, b2.Size.Height);
            Console.WriteLine("Width: original: {0}, clone: {1}",b.Size.Width, b2.Size.Width);
    
        }
    }
