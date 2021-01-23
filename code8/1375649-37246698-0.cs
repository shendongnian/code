    RectangleF a = new RectangleF(1, 2, 3, 4);
    Console.WriteLine(a);
    RectangleF b = a;   //a gets copied to b
    Console.WriteLine(b);
    a.X = 5;
    a.Y = 6;
    a.Width = 7;
    a.Height = 8;
    Console.WriteLine(a);
    Console.WriteLine(b);
