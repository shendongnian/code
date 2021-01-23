    class ComponentListComparer : IEqualityComparer<List<Component>>
    {
        public bool Equals(List<Component> x, List<Component> y)
        {
            return x.Select(c => c.Id)
                .OrderBy(c => c)
                .SequenceEqual(y.Select(c => c.Id).OrderBy(c => c));
        }
        public int GetHashCode(List<Component> obj)
        {
            return obj.Select(x => x.Id.GetHashCode() * 23).Sum();
        }
    }
