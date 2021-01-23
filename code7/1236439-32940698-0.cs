      public partial class MainWindow : Window
      {
        public class MyData
        {
          public string ItemTitle { get; set; }
          public IList<string> Usings { get; set; }
          public IList<string> Structs { get; set; }
        }
    
        public class MyViewModel
        {
          public IList<MyData> MyBoundData { get; set; }
        }
    
        public MainWindow()
        {
          var d1 = new MyData{
            ItemTitle = "thing1",
            Usings = new[]{"a", "b"}
          };
          var d2 = new MyData{
            ItemTitle = "thing2",
            Structs = new[]{"c","d"}
          };
          this.DataContext = new MyViewModel{
            MyBoundData = new[]{ d1, d2}
          };
          InitializeComponent();
        }
      }
