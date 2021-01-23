    public bool IsTakePhotoVisible => Bytes != null;
    public byte[] Bytes { 
        get {return bytes;} 
        set 
        { 
            SetValue(ref bytes, value);
            OnPropertyChanged(nameof(IsTakePhotoVisible)); 
        }
    }
