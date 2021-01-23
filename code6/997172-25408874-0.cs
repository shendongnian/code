    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FirstName"] != null && !IsPostback)
        {
            tbFirstName.Text = Session["FirstName"].ToString();
            tbLastName.Text = Session["LastName"].ToString();
            tbDOB.Text = Session["DOB"].ToString();
            tbEmail.Text = Session["Email"].ToString();
            tbTelephone.Text = Session["Telephone"].ToString();
        }
    }
