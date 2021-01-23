            dt.RejectChanges();
            for (int x = 0; x < Grid.RowCount; x++)
            {
                for (int y = 0; y < Grid.ColumnCount; y++)
                {
                    if (Grid.Rows[x].Cells[y].HasStyle)
                    {
                        Grid.Rows[x].Cells[y].Style = null;
                    }
                }
            }
