    class Comparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return string.Equals(x.Name, y.Name);
        }
        public int GetHashCode(Person obj)
        {
            string name = obj.Name;
            int hash = 7;
            for (int i = 0; i < name.Length; i++)
            {
                hash = hash * 31 + name[i];
            }
            return hash;
        }
    }
