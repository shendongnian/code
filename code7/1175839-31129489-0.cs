    // better to extend off of EqualityComparer<T> instead of
    //     implementing IEqualityComparer<T> directly
    public class NetComparer : EqualityComparer<Net>
    {
        public override bool Equals(Net x, Net y)
        {
            return (x.Id == y.Id && x.Name == y.Name);
        }
        public override int GetHashCode(Net obj)
        {
            return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
    inputNetsA = inputNetsA.Distinct(new NetComparer()).ToList();
