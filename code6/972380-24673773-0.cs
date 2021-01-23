            GridViewRow vr = GridView2.Controls[0].Controls[2] as GridViewRow;
            if (vr.RowType == DataControlRowType.DataRow)
            for(int i=0; i<=dtable.Columns.count;i++)
             {
                vr.Row[i].Text = dtableRow[i].ToString();
             }
