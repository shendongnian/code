    class Move
    {
        public uint Number { get; private set; }
        public char Src { get; private set; }
        public char Dest { get; private set; }
        public char Alt { get; private set; }
        
        public Move(uint number, char src, char dest, char alt)
        {
            this.Number = number;
            this.Src = src;
            this.Alt = alt;
            this.Dest = dest;
        }
    }
