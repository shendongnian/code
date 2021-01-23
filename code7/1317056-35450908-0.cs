    public class Value: IComparable<Value>
    {
        public int CompareTo(Value other)
        {
            if(other == null)
            {
                return 1;
            }
            return Guid.CompareTo(other.Guid);
        }
        //[...]
    }
