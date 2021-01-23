    Parallel.ForEach(DT.Rows, Row =>
    {
      try
      {
        bool check = (urlcheck(dataGridView.Rows[i].Cells[2].Value.ToString()));
        if (check == true)
            ExecuteQuery("");
        else
            ExecuteQuery("");
      }
      catch() {}
      i = i++;
    });
     
