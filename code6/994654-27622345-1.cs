    public partial class MyPage: UserControl
    {
      private MyViewModel: IViewModel;
      public MyPage()
      {
        MyViewModel = container.Resove<IViewModel>();
        InitializeComponent();
      }
    }
