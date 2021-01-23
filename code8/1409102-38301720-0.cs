    DataTable dt2 = blrate.selectmood("selectmood", mood);
    DataTable dt3 = new DataTable();
    dt3.Columns.Add("sel_musicname");
    dt3.Columns.Add("sel_musicUrl");
    for (int k = 0; k < dt2.Rows.Count; k++)
    {
        DataRow dRow = dt3.NewRow();
        dRow[0] = music.selectMusic("sel_musicname", Convert.toInt32(dt2.Rows[k][2]));
        dRow[1] = music.selectMusic("sel_musicUrl", Convert.ToInt32(dt2.Rows[k][2]));
        dt3.Rows.Add(dRow);
    }
    GridView1.DataSource = dt3;
