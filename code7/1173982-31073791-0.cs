    void AddColumn(string columnName, Column column)
    {
        if(this.Columns.Contains(columnName))
             throw new DuplicateColumnException();
        else
             this.Columns.Add(columnName, column);
    }
