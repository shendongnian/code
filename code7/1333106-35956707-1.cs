    public class NonGenericBase
    {
        protected struct IndexThing
        {
            int row; int col;
        }
    
        protected struct SomeOtherHelper
        {
            ..
        }
    }
    
    public class MyGenericType<TKey, TValue> : NonGenericBase
    {
        private struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>> { }
    
    }
