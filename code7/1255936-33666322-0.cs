    public sealed partial class MainPage : BasePage
    {
    
      public sealed class MyViewModel : BaseViewModel
      {
        public string Title
        {
          get
          {
            return "Test";
          }
        }
      }
    
      public MyViewModel LocalViewModel
      {
        get
        {
          return (MyViewModel) ViewModel;
        }
      }
    
      public MainPage()
      {
        this.InitializeComponent();
        ViewModel = new MyViewModel();
      }
    }
