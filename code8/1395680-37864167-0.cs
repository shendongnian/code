    List<DataRow> RowList = new List<DataRow>();
    int previous = 0 ;
    importSetOfTables.Tables["MyTable"].DefaultView.Sort = "ID";
    foreach (DataRowView rw in importSetOfTables.Tables["MyTable"].DefaultView)
    {
         int rowID = Convert.ToInt32(rw["ID"]);
         if (previous == rowID)
              RowList.Add(rw.Row);
         else
         {
              // Call the function that handles the duplicates
              if(RowList.Count > 1) 
                 HandleTheDuplicates(RowList);
              RowList.Clear();
         }
         previous = rowID;
    }
