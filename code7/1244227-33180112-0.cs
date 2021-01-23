        public DateTime Value { get; set; }
    
        public Func<FilterObject, DateTime, bool> Match { get; set; }
        public DateFilter(Func<FilterObject, DateTime, bool> predicate)
        {
            Match = predicate;
        }
    }
    var df = new DateFilter( (input, val) => val > input.Date));
