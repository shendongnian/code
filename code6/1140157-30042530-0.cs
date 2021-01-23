    public abstract class Model<T> where T : new()
    {
        public virtual void PostLoad() { }
        public static T Load()
        {
            Model<T> model = new ...create some type here...
    
            //assigning values
    
            model.PostLoad();
            
    
            //now what do you return?
        }
    }
