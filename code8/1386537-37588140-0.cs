    public interface InterviewQuestion<T, TResult>
    {
        TResult Method (Func<T, TResult> func);
        TResult Alternative (Func<T, TResult> func);
        bool Test ( );
    }
    public class M2SA : InterviewQuestion<Tuple<int[], int[]>, int>
    {
        private static Lazy<M2SA> lazy = new Lazy<M2SA>(() => new M2SA(), true);
        public static M2SA Instance => lazy.Value;
        public int Alternative (Func<Tuple<int[], int[]>, int> func)
        {
            throw new NotImplementedException();
        }
        public int Method (Func<Tuple<int[], int[]>, int> func)
        {
            throw new NotImplementedException();
        }
        public bool Test ( )
        {
            throw new NotImplementedException();
        }
    }
