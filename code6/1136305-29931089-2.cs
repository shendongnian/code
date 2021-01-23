    public interface IDataGenerator<out T>
    {
        int GetWeight(string matchingProperty);
        Type Type { get;}
        T Generate();
    }
    
    public abstract class DataGenerator<T> : IDataGenerator<T>
    {
        public readonly string[] Tags;
        public readonly Func<T> Generator; 
        protected DataGenerator(Func<T> generator, params string[] tags)
        {
            Tags = tags;
            //How to access this?
            Generator = generator;
        }
    	
    	public T Generate(){
    		return this.Generator();
    	}
        . . .
    }
