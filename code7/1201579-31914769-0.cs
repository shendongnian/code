    class MyBuilder
    {
        private StringBuilder bld;
        public MyBuilder() { bld = new StringBuilder(); }
        public MyBuilder KeyWord_1(string param)
        {
            this.bld.Append("Some_Keyword ").Append(param);
            return this;
        }
        public MyBuilder C
        {
            get { this.bld.Append(','); return this; }
        }
        public MyBuilder D
        {
            get { this.bld.Append(':'); return this; }
        }
        public MyBuilder E
        {
            get { this.bld.Append('-'); return this; }
        }
        public MyBuilder F
        {
            get { this.bld.Append('+'); return this; }
        }
        public MyBuilder G
        {
            get { this.bld.Append('-'); return this; }
        }
    }
