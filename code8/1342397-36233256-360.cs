    struct Big
    {
        public long U;
        public long V;
        public static Big operator ^(Big op1, Big op2)
        {
            Big b;
            b.U = op1.U ^ op2.U;
            b.V = op1.V ^ op2.V;
            return b;
        }
    }
