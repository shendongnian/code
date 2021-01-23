    class SalesItem
    {
    
        public SalesItem(_Payroll_Orders po == null, DriverData dd == null)
        {
            this._Payroll_Order = po != null ? po : new _Payroll_Orders();
            this.DriverData = dd != null ? dd : new DriverData();
        }
        private _Payroll_Orders _Payroll_Order { get; set; }
    
        public _Payroll_Orders PayrollOrder
        {
            get { return _Payroll_Order; }
            set { _Payroll_Order = value; }
        }
        public string DriverName 
        {
            get { return _Payroll_Order.Driver_Name; }
            set { _Payroll_Order.Driver_Name= value; }
        }
        public DriverData DriverData { get; set; }
        public int TerminalKey 
        {
            get { return _Payroll_Order.Trmnl_Key; }
            set { _Payroll_Order.Trmnl_Key= value; }
        }
        public int TerminalGroupKey 
        {
            get { return _Payroll_Order.TrmnlGrp_Key; }
            set { _Payroll_Order.TrmnlGrp_Key= value; }
        }
        public DateTime DeliveryDate 
        {
            get { return _Payroll_Order.Delivery_Date; }
            set { _Payroll_Order.Delivery_Date= value; }
        }
        public string CustomerLocation 
        {
            get { return _Payroll_Order.CustLoc_Description; }
            set { _Payroll_Order.CustLoc_Description = value; }
        }
        public int? CustomerLocationKey 
        {
            get { return _Payroll_Order.Ord_CustLoc_Key; }
            set { _Payroll_Order.Ord_CustLoc_Key = value; }
        }
        public bool? IsCredited 
        {
            get { return _Payroll_Order.Credits; }
            set { _Payroll_Order.Credits = value; }
        }
        public string InvoiceNumber 
        {
            get { return _Payroll_Order.Ord_Inv_No; }
            set { _Payroll_Order.Ord_Inv_No = value; }
        }
        public string TermianlGroupDesc 
        {
            get { return _Payroll_Order.TrmnlGrp_Description; }
            set { _Payroll_Order.TrmnlGrp_Description = value; }
        }
    }
