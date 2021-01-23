    class SalesItem
    {
    
        public SalesItem(_Payroll_Orders po == null)
        {
            this._Payroll_Orders = po != null ? po : new _Payroll_Orders();
        }
        private _Payroll_Orders { get; set; }
    
        public _Payroll_Orders PayrollOrder
        {
            get { return _Payroll_Orders; }
            set { _Payroll_Orders = value; }
        }
        public string DriverName 
        {
            get { return _Payroll_Orders.Driver_Name; }
            set { _Payroll_Orders.Driver_Name= value; }
        }
        public DriverData DriverData { get; set; }
        public int TerminalKey 
        {
            get { return _Payroll_Orders.Trmnl_Key; }
            set { _Payroll_Orders.Trmnl_Key= value; }
        }
        public int TerminalGroupKey 
        {
            get { return _Payroll_Orders.TrmnlGrp_Key; }
            set { _Payroll_Orders.TrmnlGrp_Key= value; }
        }
        public DateTime DeliveryDate 
        {
            get { return _Payroll_Orders.Delivery_Date; }
            set { _Payroll_Orders.Delivery_Date= value; }
        }
        public string CustomerLocation 
        {
            get { return _Payroll_Orders.CustLoc_Description; }
            set { _Payroll_Orders.CustLoc_Description = value; }
        }
        public int? CustomerLocationKey 
        {
            get { return _Payroll_Orders.Ord_CustLoc_Key; }
            set { _Payroll_Orders.Ord_CustLoc_Key = value; }
        }
        public bool? IsCredited 
        {
            get { return _Payroll_Orders.Credits; }
            set { _Payroll_Orders.Credits = value; }
        }
        public string InvoiceNumber 
        {
            get { return _Payroll_Orders.Ord_Inv_No; }
            set { _Payroll_Orders.Ord_Inv_No = value; }
        }
        public string TermianlGroupDesc 
        {
            get { return _Payroll_Orders.TrmnlGrp_Description; }
            set { _Payroll_Orders.TrmnlGrp_Description = value; }
        }
    }
