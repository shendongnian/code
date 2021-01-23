    public class MyClass
        {
            public int myInt;
    
            public MyClass(int i)
            {
                myInt = i;
            }
        }
    
        public class Starter
        {
            private MyClass myclass;
            public void Start()
            {
                myclass = new MyClass(1);
    
                var type = this.GetType();
    
                var variable = type.GetField("myclass", BindingFlags.NonPublic | BindingFlags.Instance);
    
                MyClass myOtherClass = (MyClass)variable.GetValue(this);
            }
        }
