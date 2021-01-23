    public class NewType : int
    {
        public void SomeMethod()
        {
        }
    }
    class A
    {
        private NewType x;
        public NewType X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
    }
