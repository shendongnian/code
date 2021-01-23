    class someClass
    {
        public someClass(String s)
            : this(doSomething(s))
        { }
    
        public someClass(int[] array)
        {
            doSomethingElse(array);
        }
    
        static int[] doSomething(string s)
        {
            //do something
        }
    }
