    public class MyClass
    {
        const int MAX = 10;
        public enum gender { male, female }
        public gender Gender;
        static MyClass[] cs = new MyClass[MAX];
        static MyClass()
        {
            for (int i = 0; i < MAX; i++)
            {
                cs[i] = new MyClass();
            }
        }
    }
 
