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
          else if (Object.ReferenceEquals(null, other)) 
            return 1; // let's consider that "this" (not null) > null
    
          // other is not this, and other is not null
          return Date.CompareTo(other.Date);
        }
      }
