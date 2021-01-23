    protected void repeaterSearchResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                GridView gv = e.Item.FindControl("gridView") as GridView;
                if (gv != null)
                {
                    //Bind gridview here
                }
            }
