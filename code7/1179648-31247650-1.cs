    int GetColumnIndexByName(GridViewRow row, string SearchColumnName)
            {
                int columnIndex = 0;
                foreach (DataControlFieldCell cell in row.Cells)
                {
                    if (cell.ContainingField is BoundField)
                    {
                        if (((BoundField)cell.ContainingField).DataField.Equals(SearchColumnName))
                        {
                            break;
                        }
                    }
                    columnIndex++;
                }
                return columnIndex;
            }
