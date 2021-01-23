    DataRow[] dr2 = AppConfiguration.permission.Select("MenuNameTrim = '" + this.Name + "' AND IsCanDelete = True");
     if (dr2.Length > 0)
     {
         dgvList.Columns[5].ReadOnly= true;
     } 
     else 
     {
         dgvList.Columns[5].ReadOnly = false;
     }
