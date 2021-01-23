     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<testWebApp.Post> lp = new List<testWebApp.Post>();
                Post p = new Post();
                p.ID = 1;
                Post p2 = new Post();
                p2.ID = 22;
                lp.Add(p);
                lp.Add(p2);
                rptPosts.DataSource = lp;
                rptPosts.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
 
            //Get the index of clicked row then get textbox control to get its value 
            // get row index for clicked button
            int rowIndex = Convert.ToInt32(((Button)sender).CommandArgument);
            //get input string from textbox
            string inputString = ((TextBox)rptPosts.Items[rowIndex].FindControl("TextBox2")).Text; 
            Response.Write(inputString);
        }
