    public class Parent
    {
        // Keep a table of types and default values
        protected static Dictionary<Type, Texture2D> pictureOrigin;
        
        static Parent()
        {
            // static ctor. initialize table
            pictureOrigin=new Dictionary<Type, Texture2D>();
        }
        internal static void SetDefaultPicture<T>(Texture2D picture)
        {
            // Set default based on type T
            Type type=typeof(T);
            pictureOrigin[type]=picture;
        }
        public Parent()
        {
            // Assign default based on this type
            Picture=pictureOrigin[this.GetType()];
        }
        public Texture2D Picture { get; set; }
    }
    public class SubClass1 : Parent
    {
    }
    public class SubClass2 : Parent
    {
    }
