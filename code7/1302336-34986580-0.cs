    class ObservableColor : INotifyPropertyChanged
    {
        private Color mColor;
        public Color Color
        {
            get { return mColor; }
            set
            {
                // Update mColor and fire property change notifications for "Color"
                // and for all of the individual channel properties
            }
        }
        public byte A
        {
            get { return mColor.A; }
            set
            {
                // Update mColor.A and fire property change notifications for "Color" and "A"
            }
        }
        public byte R
        {
            // Same as A, but for the R color channel
        }
        // etc.
    }
