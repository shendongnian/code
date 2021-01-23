    public class ReadonlyBucket<T> : IBucket<T>
    {
        void Add(T element) 
        {
            Console.WriteLine("Added");
        }
        void Remove(int index)
        {
           throw new NotImplementedException();
        }
    }
