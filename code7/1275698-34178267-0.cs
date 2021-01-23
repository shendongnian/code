    public interface SomeInterface
    {
        public int invoke<T>(ICollection<T> list);
    }
    public class SomeClass : SomeInterface
    {
        public int invoke<T>(ICollection<T> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                count++;
            }
            return count;
        }
    }
