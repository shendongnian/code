    class MovieSeat
    {
        public readonly string Date, Name, Number;
    
        public MovieSeat(string source)
        {
            string[] data = source.Split(';');
            Date = data[0];
            Name = data[1];
            Number = data[2];
        }
    }
