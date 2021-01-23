    struct Test
    {
        int a;
        int b;
        int c;
        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", a, b, c);
        }
    }
