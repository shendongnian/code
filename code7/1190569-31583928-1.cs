    // Make the string read only after the constructor has set it
    private readonly string colour
    public string Colour { get { return colour; } }
   
    public Apple(string colour)
    {
      this.colour = colour;
    }
    // Make the string only readonly from outside but editing from within the class
    public string Colour { get; private set; }
   
    public Apple(string colour)
    {
      this.Colour= colour;
    }
