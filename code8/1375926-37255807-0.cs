    protected void grdOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       HtmlAnchor a = new HtmlAnchor();
       a.HRef = "MPath:OpenForm " + "/root,C:\\Abhishek";
       a.ID = "a1";
    
       //System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
       //img.ID = "img1";
    
       //img.Visible = true;
       //img.ImageUrl = @"~\images\blue_camera.png";
    
       var img = new ImageButton();
       img.Click += new ImageClickEventHandler(img_Click);
       a.Controls.Add(img);
       e.Row.Cells[0].Controls.Add(a);
    }
    
    protected void img_Click(object sender, ImageClickEventArgs e)
    {
        System.Diagnostics.Process.Start(@"c:\blah.txt");
    }
