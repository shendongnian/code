    public class ContainerCheck : IEqualityComparer<Container>
    {
        private SubCheck subChecker = new SubCheck();
        public bool Equals(Container x, Container y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            if (x.IDx != y.IDx || x.IDy != y.IDy || x.Name != y.Name)
                return false;
            // check dictionary
            if (ReferenceEquals(x.Subs, y.Subs))
                return true;
            if (x.Subs == null || y.Subs == null || x.Subs.Count != y.Subs.Count)
                return false;
            foreach (var kv in x.Subs)
                if (!y.Subs.ContainsKey(kv.Key) || subChecker.Equals(y.Subs[kv.Key], kv.Value))
                    return false;
            return true;
        }
        public int GetHashCode(Container obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + obj.IDx.GetHashCode();
                hash = hash * 23 + obj.IDy.GetHashCode();
                hash = hash * 23 + obj.Name.GetHashCode();
                foreach (var kv in obj.Subs)
                {
                    hash = hash * 23 + kv.Key.GetHashCode();
                    hash = hash * 23 + subChecker.GetHashCode(kv.Value);
                }
                return hash;
            }
        }
    }
    public class SubCheck : IEqualityComparer<Sub>
    {
        public bool Equals(Sub x, Sub y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            if (x.Namex != y.Namex || x.Namey != y.Namey || x.Value != y.Value)
                return false;
            // check dictionary
            if (ReferenceEquals(x.Paths, y.Paths))
                return true;
            if (x.Paths == null || y.Paths == null || x.Paths.Count != y.Paths.Count)
                return false;
            foreach(var kv in x.Paths)
                if (!y.Paths.ContainsKey(kv.Key) || y.Paths[kv.Key] != kv.Value)
                    return false;
            return true;
        }
        public int GetHashCode(Sub obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + obj.Namex.GetHashCode();
                hash = hash * 23 + obj.Namey.GetHashCode();
                hash = hash * 23 + obj.Value.GetHashCode();
                foreach (var kv in obj.Paths)
                {
                    hash = hash * 23 + kv.Key.GetHashCode();
                    hash = hash*23 + kv.Value.GetHashCode();
                }
                return hash;
            }
        }
    } 
