    protected void Button3_Click(object sender, EventArgs e)        
         {          
            String str = " Select CODE," + DropDownList2.SelectedValu+ " From OthStk Where CODE='a103';";    
    
    SqlConnection con = new SqlConnection(your connection)
            SqlCommand xp = new SqlCommand(str, con);     
             con.Open();         
             SqlDataAdapter da = new SqlDataAdapter();     
             da.SelectCommand = xp;
             DataSet ds = new DataSet();
             da.Fill(ds,"BranchCode");   
             GridView2.DataSource = ds;
             GridView2.DataBind();
             con.Close();
         }
