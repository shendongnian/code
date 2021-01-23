    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
                if (e.CommandName == "dede")
                {
    
                    int i = 0;
    //BLL.DBClass is my Custom Connection Class
                    i = BLL.DBClass.ExecNonQueryInt("delete from table where id=" + Convert.ToInt32(e.CommandArgument) + "", null, false);
                     
                  
    
                }
    
               }
