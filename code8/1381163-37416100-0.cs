    string sql = "SELECT MemberId, Name, Address, Cellular, Email FROM Members WHERE MemberId = @Id";
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
    
    tbID.Text = dt.Rows[0]["MemberId"].ToString();
    tbName.Text = dt.Rows[0]["Name"].ToString();
    tbCellular.Text = dt.Rows[0]["Cellular"].ToString();
    tbEmail.Text = dt.Rows[0]["Email"].ToString();
    tbAddress.Text = dt.Rows[0]["Address"].ToString();
    }
