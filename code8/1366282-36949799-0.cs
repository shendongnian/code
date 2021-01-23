    public class myClassSetComperer : IEqualityComparer<HashSet<myClass>>
    {
        public bool Equals(HashSet<myClass> x, HashSet<myClass> y)
        {
            return x.SetEquals(y);
        }
        public int GetHashCode(HashSet<myClass> obj)
        {
            unchecked
            {
                int x = 0;
                foreach (var myClass in obj)
                {
                    x = (x*397) ^ myClass.GetHashCode();
                }
                return x;
            }
        }
    }
    //elsewhere
    Dictionary<HashSet<myClass>, List<MyObj>> myDict = new Dictionary<HashSet<myClass>, List<MyObj>>(new myClassSetComperer());
