    public class myDataBaseFactory
    {
        private static readonly Lazy<myDataBase> lazy =
        new Lazy<myDataBase>(() => new myDataBase());
        public static myDataBase Current { get { return lazy.Value; } }
    }
