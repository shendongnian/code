    internal class TruckItemsComparer : IEqualityComparer<TruckItems>
    {
        #region IEqualityComparer Members
        public bool Equals(TruckItems x, TruckItems y)
        {
            return (((x == null) && (y == null)) ||
                ((x != null) && (y != null) && x.TruckId == y.TruckId));
        }
        public int GetHashCode(TruckItems obj)
        {
            return obj. TruckId.GetHashCode();
        }
        #endregion
    }
