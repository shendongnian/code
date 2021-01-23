    String headLine = oStreamReader.ReadLine().Trim().Replace("\"", ""); 
    String columnNames = headLine.Split(new[] { ';' });
 
    foreach (string readColumn in columnNames)  {
    if (typeNames.Keys.Contains(readColumn, StringComparer.CurrentCultureIgnoreCase)==true)
        {
          DataColumn oDataColumn = new DataColumn(readColumn,typeof(System.String));
          oDataTable.Columns.Add(oDataColumn);
        }
