    public class CustomGridDataRowBehavior : GridDataRowBehavior
    {
        protected override bool ProcessMouseSelection(System.Drawing.Point mousePosition, GridCellElement currentCell)
        {
            bool result = base.ProcessMouseSelection(mousePosition, currentCell);
            if (result)
            {
                List<GridViewRowInfo> orderedRows = new List<GridViewRowInfo>();
                PrintGridTraverser traverser = new PrintGridTraverser(this.GridControl.MasterView);
                traverser.ProcessHiddenRows = true; 
                traverser.ProcessHierarchy = true;
                                
                while (traverser.MoveNext())
                {
                    orderedRows.Add(traverser.Current);
                }
                int minIndex = int.MaxValue;
                int maxIndex = int.MinValue;
                foreach (GridViewDataRowInfo selectedRow in this.GridControl.SelectedRows)
                {
                    int rowIndex = orderedRows.IndexOf(selectedRow);
                    if (rowIndex > maxIndex)
                    {
                        maxIndex = rowIndex;
                    }
                    if (rowIndex < minIndex)
                    {
                        minIndex = rowIndex;
                    }
                }
                this.GridControl.ClearSelection();
                for (int i = minIndex; i <= maxIndex; i++)
                {
                    if (!orderedRows[i].IsSelected)
                    {
                        orderedRows[i].IsSelected = true;
                    }
                }
            }
            return result;
        }
    }
