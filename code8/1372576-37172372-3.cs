        if( e.Row.RowType == DataRow ){
          PlaceHolder PlaceHolder1 = (PlaceHolder) e.Row.FindControl("PlaceHolder1");
          
          WebControl wc = null;
          if(Session["REGION"] != null) {
             wc = new Label();
             ((Label) wc).Text = (string) Session["REGION"];
          }
          else {
             wc = new DropDownList();
          }
          wc.ID = "txtRegion";
          PlaceHolder1.Controls.Add(wc);
        }
