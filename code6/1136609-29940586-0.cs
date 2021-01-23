    class CustomRangeAttribute : RangeAttribute {
        private double special;
        public CustomRangeAttribute(double minimum, double maximum, double special) 
              : base(minimum, maximum) {
            this.special = special;
        }
        public double Special {
            get {
                return this.special;
            }
            set {
                this.special = value;
            }
        }
        public override bool Equals(object obj) {
            CustomRangeAttribute cra = obj as CustomRangeAttribute;
            if (cra == null) {
                return false;
            }
            return this.special.Equals(cra.special) &&  base.Equals(obj);
        }
        public override int GetHashCode() {
             return this.special.GetHashCode() ^ base.GetHashCode();
        }
    
        public override bool IsValid(object value) {
            return this.special.Equals(value) || base.IsValid(value);
        }
        protected override ValidationResult IsValid(object value,
                           ValidationContext validationContext) {
            if (this.special.Equals(value)) {
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }
