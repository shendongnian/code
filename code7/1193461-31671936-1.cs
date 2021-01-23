     protected void Page_Load(object sender, EventArgs e)
     {
         if (txtData1.Text == string.Empty && Session["pg1"] != null)
          {
             txtData1.Text = Session["pg1"].ToString();
          }
      }
