    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[5];
            ints.UpdateRange(2, 4, 5);
            //ints has value [0,0,5,5,0]
        }
    }
    public static class ArrayExtensions
    {
        public static void UpdateRange<T>(this T[] array, int lowerBound, int exclusiveUpperBound, T value)
        {
            Contract.Requires(lowerBound >= 0, "lowerBound must be a positive number");
            Contract.Requires(exclusiveUpperBound > lowerBound, "exclusiveUpperBound must be greater than lower bound");
            Contract.Requires(exclusiveUpperBound <= array.Length, "exclusiveUpperBound must be less than or equal to the size of the array");
            for (int i = lowerBound; i < exclusiveUpperBound; i++) array[i] = value;
        }
    }
