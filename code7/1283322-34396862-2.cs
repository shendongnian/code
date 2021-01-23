    public class A
    {
        public static int id;
        public int ID()
        {
            return (int)this.GetType()
                .GetField("id", BindingFlags.Static | BindingFlags.Public)
                .GetValue(null);
        }
    }
    public class B : A
    {
        public static int id;
    }
