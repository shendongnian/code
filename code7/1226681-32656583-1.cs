    Range columnToRead = ws.UsedRange.Columns[columnIndex];
    System.Array myValues = (System.Array)columnToRead.Cells.Value;
    
    var output = new List<object>();
    foreach (var a in myValues ){output.Add(a);}
    List<String> myListValues = output.Select(o => o == null ? String.Empty : o.ToString()).ToList<String>();
    myListValues.RemoveAt(0);    //remove header
