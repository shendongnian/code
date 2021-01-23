    class MultipleDataContexts
    {
        public PlayerBaseClass PlayerOne { get; set; }
        public PlayerBaseClass PlayerTwo { get; set; }
        public MultipleDataContexts()
        {
            PlayerOne = new PlayerBaseClass();
            PlayerTwo = new PlayerBaseClass();
        }
    }
