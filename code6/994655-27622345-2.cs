    public partial class MyPage: UserControl
    {
      [Import(GetType(IViewModel))]
      private MyViewModel: IViewModel;
      public MyPage()
      {
         InitializeComponent();
      }
    }
