    private void client_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=.;Initial Catalog=SCP_DB;Integrated Security=True";
        con.Open();
        string query = "select  Operation_Type from Operations_Types; select ? from Payment_Type";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        da.TableMappings.Add("Table", "Operations_Types");
        da.TableMappings.Add("Table1", "Payment_Type");
        DataSet ds = new DataSet();
        da.Fill(ds, "Table");
        comboOpType.DisplayMember = "Operation_Type";
        comboOpType.ValueMember = "Operation_Type";
        comboOpType.DataSource = ds.Tables["Operations_Types"];
    
        da.Fill(ds, "Table1");
        comboPayType.DisplayMember = "Payment_Types";
        comboPayType.ValueMember = "Payment_Types";
        comboPayType.DataSource = ds.Tables["Payment_Type"];
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
