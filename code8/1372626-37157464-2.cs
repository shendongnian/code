         protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                //Check if it is not header or footer row
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                  string Failures =DataBinder.Eval(e.Row.DataItem, "YourColumnN°6Name").ToString().Trim();
                    string date = DataBinder.Eval(e.Row.DataItem, "YourColumnN°5_Name").ToString().ToString();
                    //Check your condition here 
                   if (Failures == "0" || Failures == "NULL")
                         e.Row.BackColor = Drawing.Color.Green;
                    else
                         e.Row.BackColor = Drawing.Color.Red;              
                }
              }
