    _private string _serialNumber;
    public string SerialNumber
    {
        get
        {
             return this._serialNumber;
        }
        set
        {
             this._serialNumber=value;
             RaisePropertyChanged("SerialNumber");
             this.IsSerialValid=Model.ValidateSerial(string serial);
             RaisePropertyChanged("IsSerialValid");
        }
        public bool IsSerialValid { get; set;}
    }
