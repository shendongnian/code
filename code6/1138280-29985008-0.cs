    public class MyClass
    {
        public string Ref
        {
            get
            {
                // sometimes I like to throw an exception!
                if (DateTime.Now.Ticks % 10 == 0) throw new Exception();
                return "Foo";
            }
        }
    }
