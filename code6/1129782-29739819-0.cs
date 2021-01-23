    public partial class CreateAdmin : Form
        {
            OleDbConnection db = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            public CreateAdmin()
            {
                InitializeComponent();
                db.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\ChattBankMDB.mdb";
            }
    
            private void textBox4_TextChanged(object sender, EventArgs e)
            {
    
            }
    
            private void label5_Click(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
               
                 
                db.Open();
             OleDbCommand   df = new OleDbCommand("insert into Customers(CustID,CustPassword,CustFirstName,CustLastName,CustAddress,CustEmail)" + "VALUES (?,?,?,?,?,?)", db);
                df.Parameters.AddWithValue("@CustID", iDTextt.Text);
                df.Parameters.AddWithValue("@CustPassword", passText.Text);
                df.Parameters.AddWithValue("@CustFirstName", fnText.Text);
                df.Parameters.AddWithValue("@CustLastName", lnText.Text);
                df.Parameters.AddWithValue("@CustAddress", AddText.Text);
                df.Parameters.AddWithValue("@CustEmail", EmText.Text);
                df.ExecuteNonQuery();
                db.Close();
            }
