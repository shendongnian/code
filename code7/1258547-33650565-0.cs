    public int position
    {
        get
        {
            return _position;
        }
        set
        {
            Console.WriteLine("Position is: " + position);
            // _position = position; // <-- NO, that's using the getter so _position
            _position = value;       // <-- Yes, this is the argument
        }
    }
    private int _position;
