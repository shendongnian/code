    class A
    {
        public string Text { get; set; }
        public bool isReadonly { get; set; }
        public override string ToString()
        {
            return this.Text;
        }
    }
