    [PositionType(1)]
    class Manager : Position
    {
        public override string Title
        {
            get
            { return "Manager"; }
        }
    }
    [PositionType(2)]
    class Clerk : Position
    {
        public override string Title
        {
            get
            { return "Clerk"; }
        }
    }
