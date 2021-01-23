    public class SaleInvoiceViewModel {
    
         private ObservableCollection<ProductDecorator> _productDecorators;
         [AtLeastChooseOneItem(ErrorMessage = "Choose at least one item in the following list.")]
         public ObservableCollection<ProductDecorator> ProductDecorators
         {
             get { return _productDecorators; }
             set { SetProperty(ref _productDecorators, value); }
         }
    }
    public class AtLeastChooseOneItem : ValidationAttribute
    {
        protected override ValidationResult IsValid( object value, ValidationContext validationContext )
        {
            ProductDecorator tmpEntity = (ProductDecorator) validationContext.ObjectInstance;
            var tmpCollection = (ObservableCollection<ProductUmDecorator>) value;
            if ( tmpCollection.Count == 0 )
                return ValidationResult.Success;
            foreach ( var item in tmpCollection )
            {
                if ( item.IsSelected == true )
                    return ValidationResult.Success;
            }
            return new ValidationResult( ErrorMessage );
        }
    }
