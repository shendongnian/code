    public int total = 0;
               
     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                        {  
                           
                           
                            if (e.Row.RowType == DataControlRowType.DataRow)
                            {
                                int qty = int.Parse(e.Row.Cells[0].Text);
                                total = total + qty;
                                TextBox1.Text = total.ToString();
                            }
                        }
