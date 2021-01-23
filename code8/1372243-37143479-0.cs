     public void MarkBorder(string fromColName, string toColName)
        {
             string colName = fromColName + ":" + toColName;
             CurrentWorksheet.Range[colName].BorderAround();
        }
