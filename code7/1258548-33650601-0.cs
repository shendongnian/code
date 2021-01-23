        public int position
        {
            get
            {
                return _position;
            }
            set
            {
                Console.WriteLine("Position is: " + value);
                _position = value;
            }
        }
        private int _position;
