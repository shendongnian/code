    protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlGenericControl user =(HtmlGenericControl) e.Item.FindControl("author");
                string Username = user.InnerText.ToString();
                Button btnsua = e.Item.FindControl("btnSua") as Button;
                Button btnxoa = e.Item.FindControl("btnXoa") as Button;
                if (Session["account"] != null)
                {
                    string account = Session["account"].ToString();
                    if (Username == account)
                    {
                        btnsua.Visible = true;
                        btnxoa.Visible = true;
                    }
                    else
                    {
                        btnsua.Visible = false;
                        btnxoa.Visible = false;
                    }
                }
            }
        }
