    private void LoadData()
    {
        using (var cn = new SqlConnection("Data Source=IBM369-R9WAKY5;Initial Catalog=anudatabase;Integrated Security=True"))
        {
            cn.Open();
            using(var cmd = new SqlCommand("select * from patient_db where unique_id = 123", cn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    Label9.Text = dr.GetString(1);
                    Label10.Text = dr.GetInt16(2).ToString();
                    Label11.Text = dr.GetString(6);
                    Label12.Text = dr.GetString(7);
                    TextBox1.Text = dr.GetString(3);
                    TextBox2.Text = dr.GetDecimal(4).ToString();
                }
            }
        }
    }    
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!Page.IsPostBack)
      {
          LoadData();
      }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // ... update
        LoadData();
    }
