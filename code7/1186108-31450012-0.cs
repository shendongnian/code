    public class cat
    {
        public int i = 1;
        public void func()
        {
            Console.WriteLine("I am a cat");
        }
    }
    Type type = typeof(cat);// typeof accept a Type not its instance
    string typeName = type.Name;// cat
