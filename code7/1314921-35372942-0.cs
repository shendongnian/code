    public class enregistre {
        private static Nullable<DateTime> _date;
    
        public DateTime date {
            get {
                return _date.HasValue() ? _date.Value : default(_date);
            }
            set {
                _date = value;
            }
        }
    }
