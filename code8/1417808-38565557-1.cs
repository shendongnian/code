    public string CImageBindable
            {
                get
                {
                    return base.CImageBase64;
                }
                set
                {
                    base.CImageBase64 = value;
                    OnPropertyChanged(nameof(CImageBindable));
                }
            }
