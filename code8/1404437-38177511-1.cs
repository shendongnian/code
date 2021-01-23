         public class MyClass
          {
        
            private string lastConversid;
        
            ...
        
            else if (e.CommandName == "reqconversget")
                        {
                            this.lastConversid= e.CommandArgument.ToString();
            int rowindx = ((GridViewRow)Button)e.CommandSource).NamingContainer).RowIndex;
                            GridView inrgrdview = (GridView)reqparentgird.Rows[rowindx].FindControl("reqchildgrd");
        
            inrgrdview.DataSource = dataaccesslayer.getallreqconvermsg(this.lastConversid);
                                inrgrdview.DataBind();
                        }
        
            ....
    
          protected void reqchildgrd_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView childgrd = (sender as GridView);
            childgrd.PageIndex = e.NewPageIndex;
            
            inrgrdview.DataSource = dataaccesslayer.getallreqconvermsg(this.lastConversid);
            inrgrdview.DataBind();
          }
        
        }
