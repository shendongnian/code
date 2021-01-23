    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        DataContext = this;
        List1 = new ObservableCollection<string> {"option1", "option2", "option3", "option4"};
        List2 = new ObservableCollection<string>();
        InitializeComponent();
      
      }
      private string m_selectedList1;
      public string SelectedList1
      {
        get { return m_selectedList1; }
        set
        {
          m_selectedList1 = value;
          if (m_selectedList1 == "option1")
          {
            List2.Clear();
            List2.Add("12345");
            List2.Add("123456");
          }
          if (m_selectedList1 == "option2")
          {
            List2.Clear();
            List2.Add("123");
            List2.Add("1234");
          }
        }
      }
      public ObservableCollection<string> List1 { get; set; }
      public ObservableCollection<string> List2 { get; set; }
    }
