       WinTable a = new WinTable();
       var desiredColumn = a.ColumnHeaders.FirstOrDefault(columnHeader => columnHeader.Name == "Column1");
       int indexOfColumn;
       if (desiredColumn!=null)
       {
           indexOfColumn = a.ColumnHeaders.IndexOf(desiredColumn);
       }
