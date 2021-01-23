    codes from the first page:
    
           Session["rdl1"] = RadioButtonList1.SelectedIndex;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl2"] = RadioButtonList2.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl3"] = RadioButtonList3.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl4"] = RadioButtonList4.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl5"] = RadioButtonList5.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl6"] = RadioButtonList6.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl7"] = RadioButtonList7.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl8"] = RadioButtonList8.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl9"] = RadioButtonList9.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl10"] = RadioButtonList10.Text;
                        Response.Redirect("WebForm1.aspx");
                        Session["rdl11"] = RadioButtonList11.Text;
                        Response.Redirect("WebForm1.aspx");
    
    This should be 
    
        **   Session["rdl1"] = RadioButtonList1.SelectedIndex;
                  Session["rdl2"] = RadioButtonList2.Text;
                 Session["rdl3"] = RadioButtonList3.Text;
                      
                        Session["rdl4"] = RadioButtonList4.Text;
                  
                        Session["rdl5"] = RadioButtonList5.Text;
         
                        Session["rdl6"] = RadioButtonList6.Text;
                     
                        Session["rdl7"] = RadioButtonList7.Text;
              
                        Session["rdl8"] = RadioButtonList8.Text;
                    
                        Session["rdl9"] = RadioButtonList9.Text;
             
                        Session["rdl10"] = RadioButtonList10.Text;
               
                        Session["rdl11"] = RadioButtonList11.Text;
    Response.Redirect("WebForm1.aspx");
               **
    
    As if first redirect happened then it will not save the other data in session.
