    for (int i = 0; i < 3; i++ ) {
       m.Text = ds.Tables[0].Rows[i][1].ToString();
       i.Text = ds.Tables[0].Rows[i][2].ToString();
       d.Text = ds.Tables[0].Rows[i][3].ToString();
       g.Text = ds.Tables[0].Rows[i][4].ToString();
    }
