    protected void Button1_Click(object sender, EventArgs e)
    {
    
         try
                {
                 
        
                    DataTable dt = (DataTable)Session["Dt_GridView"];
        
                 dt.DefaultView.RowFilter = "Name like '%" + textBox1.Text.Trim() + "%' ";
                 GridView1.DataSource = dt;
                  GridView1.DataBind();
                    }
                catch (Exception ex){}
    
    }
