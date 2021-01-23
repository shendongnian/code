    public C1()
    {
        InitializeComponent();
    
        using(SqlConnection MyConnection = new SqlConnection(...))
        using(SqlCommand MyCommand = new SqlCommand("SELECT * FROM taqble1", MyConnection))
        {
             DataTable dt = new DataTable();
             using(SqlDataReader reader = MyCommand.ExecuteReader())
             {
                dt.Load(reader);
                .... button code ....
             }
        }
    }
