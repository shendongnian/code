    SqlDataReader DR1;
    public void SetupData(){
         SqlConnection Conn = new SqlConnection("Data Source=SUMIT;Initial          Catalog=Project;Integrated Security=True"); 
         SqlCommand Comm1 = new SqlCommand("Select * from id", Conn); 
         Conn.Open(); 
         DR1 = Comm1.ExecuteReader();
    }
    
     void OnButtonClick(object sender, EventArgs e)
     {
                if (DR1.Read()) {
                    textBox3.Text = DR1.GetValue(0).ToString();
     }
            
