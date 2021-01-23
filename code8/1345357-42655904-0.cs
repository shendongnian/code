        public partial class Main : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\my\Documents\Visual Studio 2013\Projects\DataBase\DataBase\App_Data\List.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [Table](Id,fname,lname) values('"+TextBox3.Text+"','"+TextBox1.Text+"','"+TextBox2.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Visible = true;
            Label1.Text = "Data Stored!!";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
