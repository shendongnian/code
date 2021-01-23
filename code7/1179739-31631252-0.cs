    private Byte[] bitmap = null;
        public Byte[] Bitmap {
            get { return bitmap; }
            set { bitmap = value; }
    }
    [DataMember]
    public string BitmapBASE64 {
        get {
            return Convert.ToBase64String( bitmap );
        }
        set {
            bitmap = Convert.FromBase64String( value );
        }
    }
