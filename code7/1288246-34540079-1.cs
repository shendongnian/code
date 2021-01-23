    struct Color
    {
        public static readonly Color None = new Color(),
        public static readonly Color Red = new Color(1),
        public static readonly Color Green = new Color(2),
        public static readonly Color Blue = new Color(100)
        private int data1;
        private int data2;
        private Color(int channel){...}
    }
