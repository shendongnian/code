    public class Parent
    {
        private int a;
        public class Child
        {
            public void WriteAFromParent(Parent parent)
            {
                Console.WriteLine(parent.a);
            }
        }
    }
