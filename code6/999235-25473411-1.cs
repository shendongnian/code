    class Move
    {
        public char Src { get; private set; }
        public char Alt { get; private set; }
        public char Dest { get; private set; }
        public uint Number { get; private set; }
        public Move(uint number, char src, char dest, char alt)
        {
            Number = number;
            Src = src;
            Alt = alt;
            Dest = dest;
        }
    }
