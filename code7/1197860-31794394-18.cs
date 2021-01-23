    public class ReadonlyNumberBucket : INumberBucket
    {
        public void Add(int number)
        {
            Console.WriteLine($"Adding {number}");
        }
        public void Remove(int number)
        {
            throw new NotImplementedException();
        }
    }
