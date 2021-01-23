    // This class will compare two distinct byte arrays and check if their elements are the same
    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[] x, byte[] y)
        {
            int smallerArrayLength = Math.Min(x.Length, y.Length);
            bool elementsWithSameValue = true;
            for(int i = 0; i < smallerArrayLength; i++)
            {
                // If there is a single element which is different, we know the arrays are different and can break the loop.
                if(x[i] != y[i])
                {
                    elementsWithSameValue = false;
                    break;
                }
            }
            return elementsWithSameValue;
        }
        public int GetHashCode(byte[] obj)
        {
            int hash = 0;
            for(int i = 0; i < obj.Length; i++)
            {
                hash += obj[i].GetHashCode();
            }
            return hash;
        }
    }    
