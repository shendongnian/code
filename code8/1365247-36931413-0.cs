                for (int i = 0; i <e.Row.Cells.Count; i++)
            {
                var val = "";
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (e.Row.RowType == DataControlRowType.DataRow)
                { 
                    if (drv["Event"] != DBNull.Value)
                    { 
                        val = Convert.ToString(drv["Event"]);
                    }
                }
                e.Row.Cells[i].ToolTip = val;
            }
