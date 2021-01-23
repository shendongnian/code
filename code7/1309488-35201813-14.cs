    public class Parent
    {
        private int field;
        public class Child
        {
            public void WriteFieldFromParent(Parent parent)
            {
                Console.WriteLine(parent.field);
            }
        }
    }
