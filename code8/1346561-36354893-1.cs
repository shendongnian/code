    class Position : IEquatable<Position> {
    
      public Boolean Equals(Position other) {
        return X == other.X && Y == other.Y;
      }
    
      public override Boolean Equals(Object obj) {
        var position = obj as Position;
        return position != null ? Equals(position) : false;
      }
    
      public override Int32 GetHashCode() {
        unchecked {
          const Int32 Multiplier = -1521134295;
          var hash = -5273937;
          hash = hash*Multiplier + X.GetHashCode();
          hash = hash*Multiplier + Y.GetHashCode();
          return hash;
        }
      }
    
    }
