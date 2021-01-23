    // constructor
    public Round (int X, int Y, int radius)
    {
        this.X = X;
        this.Y = Y;
        this.radius = radius;
    }
    
    // create instance
    public static Round CreateInstance(int X, int Y, int radius)
    {
        if (!Validate(radius))
        {
            return null;
        }
        return new Round(X, Y, radius);
    }
