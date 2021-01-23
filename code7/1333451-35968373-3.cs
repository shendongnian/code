    public class BatchingProcessor<T>
    {
        private readonly IEnumerator<T> enumerator;
        public BatchingProcessor(IEnumerable<T> enumerable)
        {
            this.enumerator = enumerable.GetEnumerator();
        }
        public Batch<T> Take(int count)
        {
            var values = this.TakeUntilEndIsReached(count).ToArray();
            return new Batch<T>(values, count);
        }
        private IEnumerable<T> TakeUntilEndIsReached(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
                else
                {
                    break;
                }
            }
        }
    }
    public class Batch<T>
    {
        private readonly T[] values;
        private readonly int batchSize;
        public Batch(T[] values, int batchSize)
        {
            this.values = values;
            this.batchSize = batchSize;
        }
        public T[] Values => this.values;
        public int BatchSize => this.batchSize;
        public bool EndReached => this.values.Length < this.batchSize;
    }
