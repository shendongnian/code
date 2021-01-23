    public partial class SubMenu1 : UserControl
    {
    
         public SubMenu1()
         {
             InitializeComponent();
         } 
        public void MyFunction()
        {
             DataTable dataTable = new DataTable();
             using(SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
             using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
             {
                  myConnection.Open();
                  SqlCommand myCommand = new SqlCommand();
                  myCommand.CommandText = "SELECT * FROM Table21";
                  myCommand.Connection = myConnection;
                  sqlDataAdapter.SelectCommand = myCommand;
                  sqlDataAdapter.Fill(dataTable);
             }
             if(dataTable.Rows.Count > 0)
             {
                  //do stuff ....
             }
    
         }
    }
