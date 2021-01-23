    int   [] Col0Array = new int   [tableRead.Rows.Count] ; // first Column type is int
    string[] Col1Array = new string[tableRead.Rows.Count] ; // second Column type is int
    for (int i=0;tableRead.Rows.Count;i++)
    {
       Col1Array[i]=(int   )tableRead.Rows[i][0] ;
       Col2Array[i]=(string)tableRead.Rows[i][0] ;
    }
