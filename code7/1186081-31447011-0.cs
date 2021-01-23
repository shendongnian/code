      for (int intCnt = 0; intCnt < GridView1.Rows.Count; intCnt ++)
            {
                if (GridView1.Rows[intCnt].RowType == DataControlRowType.DataRow)
                {
                dr = dt.NewRow();
                dr["Name"] = GridView1.Rows[intCnt].Cells[0].Text;
                dr["Address"] = GridView1.Rows[intCnt].Cells[1].Text;
                dr["Number"] = GridView1.Rows[intCnt].Cells[2].Text;
                dt.Rows.Add(dr);
                }
            }
