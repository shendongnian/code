    public String imgQRCode
            {
                get { return _imgQRCode; }
                set 
                { 
                  this.RaiseAndSetIfChanged(x => x.imgQRCode, value); 
                  this.QRCode = GenerateQRCode(value);
                }
            }
