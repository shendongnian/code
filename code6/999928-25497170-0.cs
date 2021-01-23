        public class LocalizedDisplayFormatAttribute : DisplayFormatAttribute
    {
        public LocalizedDisplayFormatAttribute()
            : base()
        {
        }
        public new string NullDisplayText
        {
            get
            {
                return base.NullDisplayText;
            }
            set
            {
                base.NullDisplayText = /* Return Text */;
            }
        }
    }
