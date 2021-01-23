          protected void Page_PreRender(object sender, EventArgs e)
        {
            if(Session["Date"] != null)
            {
            string opponent = (string)Session["Opponent"];
            string location = (string)Session["Location"];
            DateTime GameDate = (DateTime)Session["Date"];
            //DateTime CalendarDate = (DateTime)Session["Calendar"];
            lblOponenet.Text = opponent;
            lblLocation.Text = location;
            lblGameDate.Text = GameDate.ToString();           
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
