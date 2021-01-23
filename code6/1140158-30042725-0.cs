    public abstract class Model
    {
        public virtual void PostLoad() { }
    }
    public abstract class Model<T> : Model where T : Model, new()
    {
        public static T Load()
        {
            T bar;
            //assigning values to bar
            ....
            //compilation error: Type `T' does not contain a definition for `PostLoad' and no extension method
            bar.PostLoad();
            return bar;
        }
    }
