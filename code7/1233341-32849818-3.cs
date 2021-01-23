    public class AlgorithmClass<TReturn>
    {
        private Dictionary<Type, Func<object, TReturn>> mMethods;
        public AlgorithmClass<TReturn>(Dictionary<Type, Func<object, TReturn>> methods)
        {
            mMethods = methods
        }
        public TReturn Invoke(object argument)
        {
            Type type = argument.GetType();
            //This line supports inheritance and co/contra-variance.
            //If you want to archive full performance and not support those features you can just use mMethods.TryGetValue(type, out Func<object, TReturn>);
            var kvps = mMethods.Where(x => x.Key.IsAssignableFrom(type));
            if(!kvp.Any())
            {
                throw new MissingMethodException("There is no method which can take " + type.Name + " as an argument");
            }
            if(kvp.Count() > 1)
            {
                throw new ArgumentException("There is more than one method which can take " + type.Name + " as an argument");
            }
            return kvp.First().Value(argument);
        }
    }
