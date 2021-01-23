    public class B : A
    {
        private Action editFunction;
        public B(string foo)
            : base()
        {
            editFunction = Edit_1;
        }
        public B(int bar)
            : base()
        {
            editFunction = Edit_2;
        }
        public override void Edit()
        {
            editFunction();
        }
        void Edit_1() { }
        void Edit_2() { }
    }
