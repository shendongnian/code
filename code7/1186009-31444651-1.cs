    public class Factor: ModelBase
    {
        private ItemViewModel _selectedFactor;
        Public ItemViewModel SelectedFactor
         {
            get
            {
               return _selectedFactor;
            }
            set
            {
             _selectedFactor = value;
              RaisePropertyChanged("RelatedQuantityFactor");
            }
         }
    }
