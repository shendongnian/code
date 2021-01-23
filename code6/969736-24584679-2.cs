    public class BindableRecord : INotifyPropertyChanged
    {
        Order _OrderObject;
        internal Order OrderObject
        {
            get { return _OrderObject; }
            set
            {
                _OrderObject = value;
                _OrderObject.PropertyChanged += OrderObject_PropertyChanged;
            }
        }
        void OrderObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
        internal Customer CustomerObject { get; set; }
        internal CustomerType CustomerTypeObject { get; set; }
        public string CustomerName
        {
            get { return this.CustomerObject.Name; }
            set { this.CustomerObject.Name = value; }
        }
        public string CustomerType
        {
            get { return this.CustomerTypeObject.ChCustomerType; }
            set { this.CustomerTypeObject.ChCustomerType = value; }
        }
        public int OrderID
        {
            get { return this.OrderObject.IdOrder; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
