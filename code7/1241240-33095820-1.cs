    public partial class Invoice : ViewModelBase
    {
        // ....
        private Nullable<decimal> quantity;
        public Nullable<decimal> Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                base.OnPropertyChanged();
                if (quantity.HasValue && unitPrice.HasValue)
                    TotalPrice = quantity * unitPrice;
            }
        }
        private Nullable<decimal> unitPrice;
        public Nullable<decimal> UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                base.OnPropertyChanged();
                if (quantity.HasValue && unitPrice.HasValue)
                    TotalPrice = quantity * unitPrice;
            }
        }
        private Nullable<decimal> totalPrice;
        public Nullable<decimal> TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                base.OnPropertyChanged();
            }
        }
    }
