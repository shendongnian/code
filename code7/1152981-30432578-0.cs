    tableRemoved = table.Clone();
    public void Execute(object param)
        {
            bool redo = (bool)param;
            if (redo)
            {
                //Yet to implement
            }
            else
            {
                tableRemoved.ImportRow(row);
                table.Rows.Remove(row);
               
            }
        }
