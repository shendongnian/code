    public class Object1 : IObject
    {
        public static implicit operator Object2 (Object1 o)
        {
            return new Object2();
        }
    }
