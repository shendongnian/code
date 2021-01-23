    string sql = `SELECT Year, Amount FROM Payments WHERE MemberId = @Id`
    SqlConnection con = new SqlConnection("myconnectionstring");
    SqlCommand cmd = new SqlCommand(sql,con);
    cmd.Parameters.Add("@Id",SqlDbType.Int).Value = tbID.Text;
    
    DataTable dt = new DataTable();
    try
    {
        con.Open();
        dt.Load(cmd.ExecuteReader());
        con.Close();
    }
    catch (Exception ex)
    {
    con.Close();
    Console.WriteLine(ex.Message);
    }
    
    cmbYear.DataSource = dt;
    cmbYear.DisplayMember = "Year";
    cmbYear.ValueMember = "Amount";
