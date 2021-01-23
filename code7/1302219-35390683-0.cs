    public class ProductDecorator : DecoratorBase<Product>
    {
         private string _ProductShortName;
         private Boolean _IsSelected = false;
         // I have omitted some code for clarity here.
         public Boolean IsSelected
         {
             get { return _IsSelected; }
             set
             {
                 SetProperty(ref _IsSelected, value);
             }
         }
    }
