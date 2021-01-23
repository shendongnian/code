    class BusLocationEqualityComparer : IEqualityComparer<BusLocation> {
    
      public Boolean Equals(BusLocation x, BusLocation y) {
        return x.BusNumber == y.BusNumber
          && x.Latitude == y.Latitude
          && x.Longitude == y.Longitude;
      }
    
      public Int32 GetHashCode(BusLocation obj) {
        unchecked {
          const Int32 Multiplier = -1521134295;
          var hash = -1901080290;
          hash = hash * Multiplier + obj.Latitude?.GetHashCode() ?? 0;
          hash = hash * Multiplier + obj.Longitude?.GetHashCode() ?? 0;
          hash = hash * Multiplier + obj.BusNumber?.GetHashCode() ?? 0;
          return hash;
        }
      }
    
    }
