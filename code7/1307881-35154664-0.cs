    public interface IArrayOperation
    {       
        bool IndexCheck(int index);
    }
    public static class TestArray
    {
        public static int GetArrayLength(this IArrayOperation arrayOperation)
        {
            int len = 0;
            while (arrayOperation.IndexCheck(len)) { ++len; }
            return len;
        }
    }
