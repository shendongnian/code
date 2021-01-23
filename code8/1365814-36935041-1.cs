    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] != null)
        {
            redPnl.Visible = false;
            UserNameSess.Text += Session["New"].ToString();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Student_Username, Student_FName, Student_SName, Student_Email FROM Student Where Student_Username=@StuUsername", con);
            sda.SelectCommand.Parameters.Add("@StuUsername", SqlDbType.VarChar).Value = UserNameSess.Text;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {  
               usernameTxt.Text = dt.Rows[0].ItemArray[0].ToString();
               firstnameTxt.Text = dt.Rows[0].ItemArray[1].ToString();
               surnameTxt.Text = dt.Rows[0].ItemArray[2].ToString();
               emailTxt.Text = dt.Rows[0].ItemArray[3].ToString();
               dt.Clear();
            }
        }
        else
        {
            redPnl.Visible = true;
        }
    }
