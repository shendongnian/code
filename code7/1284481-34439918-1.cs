    public override void Sort(DataGridViewColumn dataGridViewColumn, System.ComponentModel.ListSortDirection direction)
    {
        this.RemoveFirstItemFromDataSource();
    
        string col = dataGridViewColumn.Name;
    
        if (!this.Direction.Contains(col))
        {
            this.ClearPreviousSort();
        }
    
        string sort = this.Direction.Contains("ASC") ? "DESC" : "ASC";
        this.Direction = string.Format("{0} {1}", col, sort);
    
        this.ManuallySortSource(this.Direction);
        this.AddFirstItemToDataSource();
    }
