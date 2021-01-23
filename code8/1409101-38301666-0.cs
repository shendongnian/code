    for (int k = 0; k < dt2.Rows.Count; k++)
    {
          DataRow row = dt3.NewRow();
          row[0]= music.selectMusic("sel_musicname", Convert.ToInt32(dt2.Rows[k][2]));
          row[1] = music.selectMusic("sel_musicUrl", Convert.ToInt32(dt2.Rows[k][2]));
    
          dt3.Rows.Add(row);
    }
        GridView1.DataSource = dt3;
        GridView1.DataBind(); 
