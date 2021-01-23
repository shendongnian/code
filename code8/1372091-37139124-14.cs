    public sealed class CharEnumerator : IEnumerator, ICloneable, IEnumerator<char>, IDisposable 
    {
        private String str;
        private int index;
        private char currentElement;
 
        internal CharEnumerator(String str) {
            Contract.Requires(str != null);
            this.str = str;
            this.index = -1;
        }
 
        public Object Clone() {
            return MemberwiseClone();
        }
    
        public bool MoveNext() {
            if (index < (str.Length-1)) {
                index++;
                currentElement = str[index];
                return true;
            }
            else
                index = str.Length;
            return false;
 
        }
 
        public void Dispose() {
            if (str != null)
                index = str.Length;
            str = null;
        }
    
        /// <internalonly/>
        Object IEnumerator.Current {
            get {
                if (index == -1)
                    throw new InvalidOperationException(Environment.GetResourceString(ResId.InvalidOperation_EnumNotStarted));
                if (index >= str.Length)
                    throw new InvalidOperationException(Environment.GetResourceString(ResId.InvalidOperation_EnumEnded));                        
                    
                return currentElement;
            }
        }
    
        public char Current {
            get {
                if (index == -1)
                    throw new InvalidOperationException(Environment.GetResourceString(ResId.InvalidOperation_EnumNotStarted));
                if (index >= str.Length)
                    throw new InvalidOperationException(Environment.GetResourceString(ResId.InvalidOperation_EnumEnded));                                            
                return currentElement;
            }
        }
 
        public void Reset() {
            currentElement = (char)0;
            index = -1;
        }
    }
    
    ICollection<TElement> collection = source as ICollection<TElement>;
    if (collection != null) {
        count = collection.Count;
        if (count > 0) {
            items = new TElement[count];
            collection.CopyTo(items, 0);
        }
    }    
