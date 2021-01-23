    public static class SOExtensions
    {
        public static IEnumerable<T> GetLastAndFirst<T>(this IEnumerable<T> seq, int number, int totalLength)
        {
            if(totalLength < number*2) 
                throw new Exception("List length must be at least two times of number");
            using (var en = seq.GetEnumerator())
            {
                int i = 0;
    
                while (en.MoveNext())
                {
                    i++;
                    if (i <= number || i >= totalLength - number) 
                         yield return en.Current;
                }
            }
        }
    }
