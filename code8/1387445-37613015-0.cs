    public Form2()
    {
        InitializeComponent();
        string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string path = (System.IO.Path.GetDirectoryName(executable));
        AppDomain.CurrentDomain.SetData("DataDirectory", path);
        this.connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database.accdb;User Id=admin; Password=;");
    }
