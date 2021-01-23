    public abstract class GenericBase<T>
    {
        public static bool AOTConstruct()
        {
            bool b = (new GV<T>() == null); // Where GV<T> is a Generic Class.
            // Do similar for all Generic Classes that need to be AOT compiled.
            return b;
        }
    }
