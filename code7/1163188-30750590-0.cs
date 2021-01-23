    private async void button2_Click(object sender, EventArgs e)
    {
        ProgressBar1.Visible = true;
        ProgressBar1.Style = ProgressBarStyle.Marquee;
        var period1=comboBox3.SelectedValue.ToString();
        var period2=comboBox2.SelectedValue.ToString();
        //This will run in the background
        var table=await Task.Run(()=>LoadTable(period1,period2));
        
        //We're back in the UI
        datagridview1.DataSource = table;
        ProgressBar1.Visible = false;    
    }
    private async Task<DataTalbe> LoadTable(string period1, string period2)
    {
         string C = ConfigurationManager.["DB"].ConnectionString;
         using(var con = new SqlConnection(C))
         using(var cmd = new SqlCommand())
         {
             cmd.Connection = con;
             cmd.CommandText = ("[dbo].[spInfo]");
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Periode2",period2);
             cmd.Parameters.AddWithValue("@Periode1", period1);
             
             con.Open();
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             adapter.Fill(dt);
             return dt;
        }
    }
