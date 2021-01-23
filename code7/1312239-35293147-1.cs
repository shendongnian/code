    public C1()
    {
        InitializeComponent();
        using(SqlConnection MyConnection = new SqlConnection(...))
        using(SqlCommand MyCommand = new SqlCommand("SELECT * FROM taqble1", MyConnection))
        using(SqlDataAdapter adapter = new SqlDataAdapter(MyCommand))
        {
             DataTable dt = new DataTable();
             adapter.Fill(dt);
             .... button code ....
        }
    }
