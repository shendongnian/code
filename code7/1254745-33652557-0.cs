    static void Main(string[] args)
    {
        Console.WriteLine("Graphics in console window!");
        Point location = new Point(10, 10);
        Size imageSize = new Size(20, 10); // desired image size in characters
        // draw some placeholders
        Console.SetCursorPosition(location.X - 1, location.Y);
        Console.Write(">");
        Console.SetCursorPosition(location.X + imageSize.Width, location.Y);
        Console.Write("<");
        Console.SetCursorPosition(location.X - 1, location.Y + imageSize.Height - 1);
        Console.Write(">");
        Console.SetCursorPosition(location.X + imageSize.Width, location.Y + imageSize.Height - 1);
        Console.WriteLine("<");
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures), @"Sample Pictures\tulips.jpg");
        using (Graphics g = Graphics.FromHwnd(GetConsoleWindow()))
        {
            using (Image image = Image.FromFile(path))
            {
                Size fontSize = GetConsoleFontSize();
                // translating the character positions to pixels
                Rectangle imageRect = new Rectangle(
                    location.X * fontSize.Width,
                    location.Y * fontSize.Height,
                    imageSize.Width * fontSize.Width,
                    imageSize.Height * fontSize.Height);
                g.DrawImage(image, imageRect);
            }
        }
    }
