    private void bind_checkbox_inst_type()
     {
         string qur = @"SELECT  inst_type FROM    institute_type";
     DataTable dt =Connstring. SqlDataTable(qur);
         if (dt.Rows.Count > 0)
         {
             for (int i = 0; i <= Chk_type.Items.Count - 1; i++)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     if (Chk_type.Items[i].Text == dr["inst_type"].ToString().Trim())
                    {
                      Chk_type.Items[i].Selected=true ;
                      break;
                    }
                    
                 }
             }
            
         
         }
     }
