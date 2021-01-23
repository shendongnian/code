    private void button1_Click(object sender, EventArgs e)
    {
         SqlConnection cn = new SqlConnection("Data Source=PCN-TOSH;Initial Catalog=mydb;Integrated Security=True");
         cn.Open();
         SqlCommand cm = new SqlCommand(@"Insert into TableDate_Time 
                                          (DateTime ) values (@DateTime);
                                          SELECT SCOPE_IDENTITY()");
         cm.Parameters.Add("@DateTime", SqlDbType.DateTime);
         cm.Parameters["@DateTime"].Value = DateTime.Now;  
         cm.Connection = cn;
         int id = Convert.ToInt32(cm.ExecuteScalar());
    }
