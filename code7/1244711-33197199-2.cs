    public static class States
    {
         public const int Open = 1;
         public const int Closed = 2;
    }
    
    public static class Materials
    {
        public const int Steel = 1;
        public const int Wood = 1;
    }
    
    // true! but not that true... I can't understand why these constants equal...
    if(States.Open == Materials.Wood)
    {
    }
