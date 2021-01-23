     public class ShellViewModel : Screen
     {
           private ProductViewModel _productViewModel;
           public ShellViewModel (){
             
               
           }
           protected override void OnActivate(){
             ProductViewModel = IoC.Get<ProductViewModel>();
           }
           public ProductViewModel ProductViewModel {
              get{ return _productViewModel;}
              set{
                    _productViewModel = value;
                    NotifyOfPropertyChanged (); // 2.0.2 feature...
              }
      }
