    public class OneBasedArray<T>
    {
        public T[] InnerArray;
        public T this[int i]
        {
            get { return InnerArray[i-1]; }
            set { InnerArray[i-1] = value; }
        }
    }
