    public interface IArrayOperation
    {       
        int GetArrayLength();
    }
    public static class TestArray
    {
        public static bool IndexCheck(this IArrayOperation arrayOperation, int index)
        {
            return index >= 0 && index < arrayOperation.GetArrayLength();
        }
    }
