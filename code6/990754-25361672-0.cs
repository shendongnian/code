     protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        
            try 
            {
            //    //Update the values.
            
                string type = e.NewValues[0].ToString();
                string qty = e.NewValues[1].ToString();
              
                //Retrieve the table from the session object.
                DataTable dt = (DataTable)Session["table_detail"];
                dt.Rows[e.RowIndex]["TicketType"] = type;
                dt.Rows[e.RowIndex]["TicketNo"] = qty;
                dt.AcceptChanges();
                chkoutDetail.EditIndex = -1;
                //Bind data to the GridView control.
                gridbind();
                int value1 = Convert.ToInt32(ddtickettype.SelectedItem.Value);
                int value2 = Convert.ToInt32(ddTicketno.SelectedItem.Value);
                string tType = ddtickettype.SelectedItem.Text;
                string tNo = ddTicketno.SelectedItem.Text;
                
                int prevTotal = Convert.ToInt32(lblAmount.Text);
                int total = (value1 * value2) + prevTotal;
                Session["TotalAmount"] = total.ToString();
                if (Session["TotalAmount"] != null)
                {
                    lblAmount.Text = Session["TotalAmount"].ToString();
                }
                
               
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }
