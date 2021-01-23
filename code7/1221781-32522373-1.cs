    public class Child : BaseClass
    {
        public Child(int x)
          : base(x + 5) // since X is private, let's move logic into the call
        {
        }
    }
