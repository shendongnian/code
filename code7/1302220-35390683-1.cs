    public class SaleInvoiceViewModel {
         private ObservableCollection<ProductDecorator> _productDecorators;
         public ObservableCollection<ProductDecorator> ProductDecorators
         {
              get { return _productDecorators; }
              set { SetProperty(ref _productDecorators, value); }
         }
         public SaleInvoiceViewModel() {
               _productDecorators= new ObservableCollection<ProductDecorator>();
               _productDecorators.CollectionChanged += ContentCollectionChanged;
         }
         public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
         {
              if (e.Action == NotifyCollectionChangedAction.Remove)
              {
                  foreach(ProductDecorator item in e.OldItems)
                  {
                       //Removed items
                       item.PropertyChanged -= EntityPropertyChanged;
                  }
              }
             else if (e.Action == NotifyCollectionChangedAction.Add)
             {
                  foreach(ProductDecorator item in e.NewItems)
                  {
                      //Added items
                      item.PropertyChanged += EntityPropertyChanged;
                  }     
             }       
        }
    }
