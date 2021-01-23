    protected void Button4_Click(object sender, EventArgs e)
    {
    Insertdata()
    }
    
    public void Insertdata()
    {
    SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=FRMDEVSQL03; Initial Catalog=VisualStudioTest; User ID=Aghosh; Password=SummerClerk");
            sc.Open();
            com.Connection = sc;
            com.CommandText = (@"INSERT INTO ticket(person_created, category_id, summary, ticket_status) VALUES ('" + txtName.Text + "',  '" + Label5.selectedvalue + "', '" + txtName0.Text + "', '" + Label4.selectedvalue + "');");
            com.CommandText = (@"INSERT INTO persons(LanID) VALUES ('" + txtName.Text + "');");
            //com.CommandText = (@"INSERT INTO ticket(person_created, summary) VALUES ('" + txtName.Text + "','" + txtName0.Text + "');");
            com.ExecuteNonQuery();
            sc.Close();
            Response.Redirect(Request.RawUrl);
    }
