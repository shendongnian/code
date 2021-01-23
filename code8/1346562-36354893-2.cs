    class PositionEqualityComparer : IEqualityComparer<Position> {
    
      public Boolean Equals(Position position1, Position position2) {
        return position1.X == position2.X && position1.Y == position2.Y;
      }
    
      public Int32 GetHashCode(Position position) {
        unchecked {
          const Int32 Multiplier = -1521134295;
          var hash = -5273937;
          hash = hash*Multiplier + position.X.GetHashCode();
          hash = hash*Multiplier + position.Y.GetHashCode();
          return hash;
        }
      }
    
    }
