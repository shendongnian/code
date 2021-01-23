     protected void Page_Load(object sender, EventArgs e)
     {
         if (Session["pg1"] != null)
          {
             txtData1.Text = Session["pg1"].ToString();
          }
      }
