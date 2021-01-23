        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(Session["id"]);
            Label3.Text = Convert.ToString(Session["name"]);
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int id1=Convert.ToInt32(Session["id"]);
            TransferDAL dalob = new TransferDAL();
            int x = dalob.updateapprove(id1);
            
            Response.Redirect("View.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt32(Session["id"]);
            TransferDAL dalob = new TransferDAL();
            int r = dalob.updatereject(id1);
            Response.Redirect("View.aspx");
        }
    }
