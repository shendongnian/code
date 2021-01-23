    public interface IModelLifeCycle
        {
            void PostLoad();
        }
        public abstract class Model<T> where T : IModelLifeCycle
        {
            public static T Load()
            {
                T bar = default(T);
                //assigning values to bar
    
    
                //compilation error: Type `T' does not contain a definition for `PostLoad' and no extension method
                bar.PostLoad();
                return bar;
            }
        }
