    public class Bar1 : Bar
    {
        public override void DoSomething()
        {
            if (this.Parent == null)
            {
                throw new ArgumentException("Parent cannot be null");
            }
            // code against parent
            Console.WriteLine("Bar 1 doing something");
        }
    }
    public class Bar2 : Bar
    {
        public override void DoSomething()
        {
            if (this.Parent == null)
            {
                throw new ArgumentException("Parent cannot be null");
            }
            // code against parent
            Console.WriteLine("Bar 2 doing something");
        }
    }
