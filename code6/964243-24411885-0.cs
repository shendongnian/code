    public List<SupplierInvoice> SupplierInvoices
    {
        get
        {
            return this._SupplierInvoices;
        }
        set
        {
            if (this._SupplierInvoices != value)
            {
                this._SupplierInvoices = value;
                this.RaisePropertyChanged("SupplierInvoices");
                this.RaisePropertyChanged("ApTotal");
            }
        }
    }
