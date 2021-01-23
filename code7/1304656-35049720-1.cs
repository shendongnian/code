    public class TransactionItemViewModel : BaseViewModel
    {
        int _Quantity;
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    RaisePropertyChanged("Quantity");
                    RaisePropertyChanged("TotalSalePrice");
                }
            }
        }
        public decimal TotalSalePrice
        {
            get
            {                                
                return 100 * Quantity;
            }
        }
    }
