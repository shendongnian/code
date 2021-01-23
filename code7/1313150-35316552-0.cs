    class foo
    {
        private byte bar;
        public int BarAsInt
        {
            get { return Convert.ToInt32(bar); }
            set { bar = Convert.ToByte(value); }
        }
        public string BarAsString
        {
            get { return bar.ToString(); }
            set { bar = byte.Parse(value); }
        }
    }
