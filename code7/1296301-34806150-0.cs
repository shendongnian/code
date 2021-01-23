    protected void button1_Click_1(object sender, EventArgs e) {
        UpdateLastNumber();
        txtjobno.Text = "LEL5-" + GetLastNumber().ToString();
    }
    
    protected int GetLastNumber(){
        int last = 0;
        OleDbConnection con = new OleDbConnection(WebConfigurationManager.ConnectionStrings["YourConnectionStringnameFromWebConfigFile"].ConnectionString);
        OleDbCommand cmd = new OleDbCommand("select lastnumber from serial_numbers where id = 1", con); // I added the condition just to be sure that only one value will be queried
        con.Open();
        last = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        con.Close();
        return last;
    }
    protected void UpdateLastNumber(){
        OleDbConnection con = new OleDbConnection(WebConfigurationManager.ConnectionStrings["YourConnectionStringnameFromWebConfigFile"].ConnectionString);
        OleDbCommand cmd = new OleDbCommand("update serial_numbers set lastnumber = lastnumber + 1 where id = 1", con); // I added the condition just to be sure that only one value will be queried
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
