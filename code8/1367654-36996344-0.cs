    public DataTable RemoveDuplicateRows(DataTable dataTable, string columnName)
    {
       Hashtable hashTable = new Hashtable();
       ArrayList duplicateList = new ArrayList();
       //Add a list of all the unique item values to the hashtable, which in turn stores a combination of key, value pair.
       //And add duplicate item value in arraylist.
       foreach (var dataRow in dataTable.Rows)
       {
          if (hashTable .Contains(dataRow[columnName]))
         duplicateList.Add(dataRow);
      else
         hTable.Add(dataRow[columnName], string.Empty); 
       }
       //Removing a list of duplicate items from datatable.
       foreach (var dRow in duplicateList)
      dataTable.Rows.Remove(dRow);
       //Datatable which contains unique records will be return as output.
      return dataTable;
    }
