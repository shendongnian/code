    public Form1(string productCodevalue){
    InitializeComponent();
    string connectionString = "Data Source=localhost \\SqlExpress;Initial Catalog=MMABooks;" + "Integrated Security=True";
    Object returnValue;
    SqlConnection connection = new SqlConnection(connectionString);
    string selectStatement = "SELECT Top 1 ProductCode " + "FROM Products " + "WHERE ProductCode = @ProductCode";
    SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
    selectCommand.Commandtype = CommandType.Text;
    selectCommand.Parameters.Add("ProductCode", SqlType.VarChar).Value = productCodevalue;
    connection.Open();
    returnValue = selectCommand.ExecuteScalar();
    connection.Close();
    txtDisplay.Text = returnValue.ToString();
}`
