    public class MainViewModel : BindableBase
    {
        FirstViewModel firstViewModel;
        public FirstViewModel FirstViewModel
        {
            get
            {
                return firstViewModel;
            }
            set
            {
                firstViewModel = value;
            }
        }
        public SecondViewModel SecondViewModel
        {
            get
            {
                return secondViewModel;
            }
            set
            {
                secondViewModel = value;
            }
        }
        SecondViewModel secondViewModel;
        public MainViewModel()
        {
            firstViewModel = new FirstViewModel();
            secondViewModel = new SecondViewModel();
        }
    }
