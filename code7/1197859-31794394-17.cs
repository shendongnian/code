     public class NumberBucket : INumberBucket
    {
        public void Add(int number)
        {
            Console.WriteLine($"Adding {number}");
        }
        public void Remove(int number)
        {
            Console.WriteLine($"Removing {number}");
        }
    }
