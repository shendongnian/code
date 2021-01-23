    class Parent
    {
        protected string myString = "I don't want this one";
        public void MyMethod()
        {
            Console.Write(myString);
        }
    }
    class Child : Parent
    {
        public Child()
        {
            myString = "I want this one";
        }
    }
