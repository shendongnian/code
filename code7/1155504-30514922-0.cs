         protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
       
            if (rd.SelectedValue == "1")
            {
                CrystalReportViewer2.Visible = false;
            
                yl.Visible = false;
                yt.Visible = false;
             
            }
            if (rd.SelectedValue == "2")
            {
                CrystalReportViewer1.Visible = false;
             
            
                sdate.Visible = false;
            }
        }
