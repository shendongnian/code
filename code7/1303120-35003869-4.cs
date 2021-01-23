    public const string ColourImagePropertyName = "ColourImage";
        private WriteableBitmap  colourBitmap =  null;
        public WriteableBitmap  ColourImage
        {
            get
            {
                return colourBitmap ;
            }
            set
            {
                if (Equals(colourBitmap, value))
                {
                    return;
                }
                colourBitmap  = value;
                RaisePropertyChanged(ColourImagePropertyName);
            }
        }
