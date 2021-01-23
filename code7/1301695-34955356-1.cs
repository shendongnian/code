    public static implicit operator Int32(Point p)
    {
        Console.WriteLine("Converted to Int32");
        return p.y + p.x;
    }
