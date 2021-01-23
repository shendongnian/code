     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<testWebApp.Post> lp = new List<testWebApp.Post>();
                testWebApp.Post p = new testWebApp.Post();
                p.ID = 1;
                testWebApp.Post p2 = new testWebApp.Post();
                p2.ID = 22;
                lp.Add(p);
                lp.Add(p2);
                rptPosts.DataSource = lp;
                rptPosts.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(((Button)sender).CommandArgument); // get saved ID for clicked row
            //Get your post by Id and do whatever you want
            Response.Write(Id.ToString());
        }
