    void SetColumn(string columnName, Column column)
    {
        if(this.Columns.Contains(columnName))
             this.Columns[columnName] = column;
        this.Columns.Add(columnName, column);
    }
