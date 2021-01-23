    public class MainViewModel : Conductor<object> {
        //...
        private readonly Func<MySecondViewModel> mySecondViewModelFactory;
        public MyMainViewModel(IWindowManager windowManager, Func<MySecondViewModel> mySecondViewModelFactory) {
            this.mySecondViewModelFactory = mySecondViewModelFactory;
            //...do the init
        }
        
        public void ShowPageOne() {
            var item = mySecondViewModelFactory(); //invoke factory
            ActivateItem(item);
        }
    }
    
