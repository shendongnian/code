    protected void Page_Load(object sender, EventArgs e)
        {
            String userID = Convert.ToString(Session["user_id"]);        
            if (string.IsNullOrEmpty(userID) == true)
            {            
                Response.Redirect("login.aspx");
            }
    
            try { 
                string scon="SERVER=localhost;DATABASE=bmtc;UID=root;";
                MySqlConnection con = new MySqlConnection(scon);
                String s = "select * from application";
                MySqlDataAdapter dat = new MySqlDataAdapter(s, con);
                DataSet ds = new DataSet();
                dat.Fill(ds,"tbl");
                listview1.DataSource = ds.Tables[0];
                listview1.DataBind();
            }
    
            catch(Exception ex){
               // Label1.Text = ex.ToString();
        }
    }
