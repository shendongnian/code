     protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    
      {
       ImageButton imgbtn = (ImageButton)sender;
       GridViewRow GridView1Row = (GridViewRow)imgbtn.NamingContainer;
       Label FLabel = GridView1Row.Cells[2].Controls[0].FindControl("Label1") as Label;
                    string workordernum = FLabel.Text;// GridView1Row.Cells[3].Text;
                    
                    TextBox10.Text = workordernum;
                
                        ModalPopupExtender2.Show();
                        DetailsView2.Visible = true;
                        ModalPopupExtender1.Show();
                        DetailsView1.Visible = true;
                       
                
       
            }
