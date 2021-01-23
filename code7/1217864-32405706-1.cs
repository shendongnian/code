    public class TestClass
    {
        public void ParentMethod()
        {
            try
            {
                ChildMethod1();
                ChildMethod2();
            }
            catch (InvalidStateException ise)
            {
                return;
            }
        }
        public void ChildMethod1()
        {
            //do stuff, and then if the "watch" is set to true:
            throw new InvalidStateException();
        }
        public void ChildMethod2()
        {
            //do stuff, and then if the "watch" is set to true:
            throw new InvalidStateException();
        }
    }
    public class InvalidStateException : Exception { }
