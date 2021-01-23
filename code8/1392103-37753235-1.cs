    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex >= 0)
            {
                for (int i = 0; i < e.Row.Cells.Count - 1; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    if (cell.Visible)
                    {
                        int colSpanValue = 1;
                        for (int j = i + 1; j < e.Row.Cells.Count; j++)
                        {
                            TableCell otherCell = e.Row.Cells[j];
                            if (otherCell.Text == cell.Text)
                            {
                                colSpanValue++;
                                otherCell.Visible = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (colSpanValue > 1)
                        {
                            cell.ColumnSpan = colSpanValue;
                            cell.BackColor = Color.Beige;
                            cell.HorizontalAlign = HorizontalAlign.Center;
                        }
                    }
                }
            }
        }
    }
