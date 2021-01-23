    class ClassThatNeedsAReferenceToMyContext
    {
        public ClassThatNeedsAReferenceToMyContext(MyContext context)
        {
            this.theContext = context;
        }
        public MyContext theContext { get; set; }
    }
