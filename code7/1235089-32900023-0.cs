        private Random rnd = new Random();
        private Color[] Colors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Purple };
        public Color RandomColor()
        {
            return Colors[rnd.Next(Colors.Length)];
        }
