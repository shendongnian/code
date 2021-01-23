      class Sortsample: IComparable<Sortsample> {
        public DateTime Date {
          get; set;
        }
        public string Name {
          get; set;
        }
    
        public int CompareTo(Sortsample other) {
          // if "other" is, in fact, "this" 
          if (Object.ReferenceEquals(this, other))
            return 0;
          else if (Object.ReferenceEquals(null, other)) // let's consider that this > null
            return 1;
    
          // other is not this, and other is not null
          return Date.CompareTo(other.Date);
        }
      }
