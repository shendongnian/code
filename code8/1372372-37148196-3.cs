    public partial class Window1 : Window
    {
      ComboViewModel dataContext = new ComboViewModel();
      public Window1()
      {
         InitializeComponent();
         dataContext.Items=new List<string>(new string[]{"First Item","Second Item"});
         this.DataContext = dataContext;
      }
      private void displaySelected_Click(object sender, RoutedEventArgs e)
      {
         MessageBox.Show(String.Format("Selected item:\n\nIndex: {0}\nValue: {1}", dataContext.Index, dataContext.Value));
      }
    }
