    class A
    {
        public void Y()
        {
            Console.WriteLine("Y about to happen");
            InnerY();
            Console.WriteLine("Y happened");
        }
        protected virtual void InnerY()
        {
        }
    }
    
    class B : A
    {
        protected override void InnerY()
        {
            //No need to log - already done
        }
    }
