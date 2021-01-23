    public abstract class Model<T> where T : new()
        {
            public virtual void PostLoad() { }
            public static Model<T> Load()
            {
                Model<T> bar = null;
                //assigning values to bar
    
    
                //compilation error: Type `T' does not contain a definition for `PostLoad' and no extension method
                bar.PostLoad();
                return bar;
            }
        }
