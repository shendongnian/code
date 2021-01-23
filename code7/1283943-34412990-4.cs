    public partial class MyWindow : Window, IDbWindow
    {
       public string Key { get; private set; }
       public DbContext Db { get; private set; }
       public MyWindow()
       {
          InitializeComponent();
          Key = "ThisIsTheWindowImLookingFor"; // this key might be set somewhere else, or be passed in the constructor, or whatever
          Db = new MyDbContext(); // for example
       }
    }
