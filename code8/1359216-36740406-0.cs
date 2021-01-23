      class Sortsample: IComparable<Sortsample> {
        public DateTime Date {
          get; set;
        }
        public string Name {
          get; set;
        }
    
        public int CompareTo(Sortsample other) {
          if (Object.ReferenceEquals(this, other))
            return 0;
          else if (Object.ReferenceEquals(null, other))
            return 1;
    
          return Date.CompareTo(other.Date);
        }
      }
