    class DistinctItemComparer : IEqualityComparer<Trip> {
    public bool Equals(Item x, Item y) {
        return x.Port == y.Port &&
            x.TripId== y.TripId;
    }
    public int GetHashCode(Trip obj) {
        return obj.Port.GetHashCode() ^
            obj.TripId.GetHashCode();
    }
