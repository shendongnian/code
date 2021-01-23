    public class customDict<TValue> : Dictionary<int, TValue> where TValue : class
    {
        public int this[TValue index]
        {
            get
            {
                var retVal = this.Where(e => e.key == index);
                if (retVal.Count() == 1)
                {
                    return retVal.First().Value;
                }else
                {
                    return default(TValue);
                }
            }
        }
    }
