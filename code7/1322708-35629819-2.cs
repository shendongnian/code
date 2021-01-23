        public partial class message : System.Web.UI.Page
        {
            string constring = ConfigurationManager.ConnectionStrings["AnonymiousSocialNetworkConnectionString"].ToString();
        
            protected void Page_Load(object sender, EventArgs e)
            {           
                txtuseremil.Text = Session["emid"].ToString();
            }
            protected void btnsend_Click(object sender, ImageClickEventArgs e)
            {
                SqlConnection con = new SqlConnection(constring);
                string value = txtmsg.Text;
                SqlCommand cmd = new SqlCommand("select keyword from messageanalysis where keyword like @value")
                
                cmd.Parameters.AddWithValue("@value", yourValue);
                cmd.Connection=con;
                con.Open();
                if (value.Contains(cmd.ExecuteScalar()))         
                {
                    
                    lblStatus.Text = "Normal";
                    Frdsclass.Text = "Just Friend";
                    SqlCommand cmd = new SqlCommand("insert into messagetable(sendid,message,userid,emotional,friendsclassify) values (@snd,@msg,@usr,@emo,@frdcl)", con);
                    cmd.Parameters.AddWithValue("@snd", txtsndmail.Text);
                    cmd.Parameters.AddWithValue("@msg", txtmsg.Text);
                    cmd.Parameters.AddWithValue("@usr", txtuseremil.Text);
                    cmd.Parameters.AddWithValue("@emo", lblStatus.Text);
                    cmd.Parameters.AddWithValue("@frdcl", Frdsclass.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
