    public class F1
    {
        public readonly int k1;
        public F1(int k1)
        {
          ...
        }
        public F1 GetModifiedCopy(int newVal)
        {
            return new F1(newVal);
        }
    }
