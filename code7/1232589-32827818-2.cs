    public class Object1 : IObject
    {
        public static implicit operator Object2 (Object1 o)
        {
            // Somehow convert o into an Object2
            return new Object2();
        }
    }
