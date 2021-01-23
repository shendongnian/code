      DataTable dt= jb.Pieces.CopyToDataTable();
      dt.Columns.Add("UserId")
      for(int i=0;i<dt.Rows.Count;i++)
      {
            dt.Rows[i]=//Your info
      }
      db.DataSource = dt;
      db.DataBind();
