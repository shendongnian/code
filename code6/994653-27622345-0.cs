    public partial class MyPage: UserControl
    {
      private MyViewModel: IViewModel;
      public MyPage()
      {
         MyViewModel = MyViewModelFactory.Create(IViewModel);
         InitializeComponent();
      }
    }
