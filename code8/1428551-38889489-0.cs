    int straszeint=0;
    for (int i = 0; i < datagridview.Columns.Count; i++)
    {
       if (datagridview.Columns[i].Name.Equals(straszennamen))
       {
         // Let it is false for all iterations
         straszeint = i;
         break;
       }
    }
    // straszeint will be zero here if the condition is false for all iteration
