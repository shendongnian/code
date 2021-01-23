    class MyClass
    {
        public Gender MyGender { get; set }
        public enum Gender { male, female }
    
        MyClass[] cs = new MyClass[];
        
        public static void DoSomething()
        {
            for (int i = 1; i < max; i++)
            {
                cs[i].MyGender = MyClass.Gender.male; 
            }
        }
    }
