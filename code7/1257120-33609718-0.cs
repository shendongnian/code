     protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
            {
               if(e.Item.ItemType == ListItemType.Item|| e.Item.ItemType == ListItemType.AlternatingItem)
                {
                Label l = (Label)e.Item.FindControl("Label1");
                string s = l.Text;
                 }
            }
