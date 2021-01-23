    using System;
    using System.Drawing;
    void Main()
    {
        var c = Color.FromArgb(unchecked((int)0xaa336539));
        Console.WriteLine("Alpha: {0}", c.A);
        Console.WriteLine("Red: {0}", c.R);
        Console.WriteLine("Green: {0}", c.G);
        Console.WriteLine("Blue: {0}", c.B);
    }
