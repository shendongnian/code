     protected void CreatePages(int startingPoint, int checkingPoint, int endPoint, Button button)
            {
                List<ListItem> pages = new List<ListItem>();
                for (i = startingPoint; i < endPoint; i++)
                {
                if (i < checkingPoint)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != PageIndex));
                    if (i == endPoint)
                    {
                        button.Visible = false;
                    }
               }
                }
                Session["lastnumber"] = checkingPoint;
                Session["pagecount"] = endPoint;
                rptPager.DataSource = pages;
                rptPager.DataBind();
                }
       protected void lnknext_Click(object sender, EventArgs e)
        {
            int pagecount = Convert.ToInt32(Session["pagecount"].ToString());
            int lastnumber = Convert.ToInt32(Session["lastnumber"].ToString());
            int nexttennumber = lastnumber + 10;
            CreatePagesAndBindRepeater(lastnumber, nexttennumber, pagecount, lnknext);
            }
