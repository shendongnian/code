    class A : I1, I2
    {
        public void I1.x()
        {
            Console.WriteLine("hello I1");
        }
        public void I2.x()
        {
            Console.WriteLine("hello I2");
        }
    }
