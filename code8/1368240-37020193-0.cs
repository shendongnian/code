                if (lastnumber <= 6)
                {
                    for (int i = limit; i <= pagecount; i++)
                    {
                        pages.Add(new ListItem(i.ToString(), i.ToString(), i != PageIndex));
                    }
                }
                else
                {
                    rptPager.DataSource = Session["orignalpages"];
                    rptPager.DataBind();
                }
