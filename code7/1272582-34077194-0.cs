    public class StringList : List<String>
    {
        public override bool Equals(object obj)
        {
            StringList other = obj as StringList;
            if (other == null) return false;
            return this.All(x => other.Contains(x));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (String s in this)
                {
                    hash = hash + s.GetHashCode() * 31;
                }
                return hash;
            }
        }
    }
