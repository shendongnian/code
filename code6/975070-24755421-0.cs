    Parallel.ForEach(DT, (row2, loopState, i) =>
    {
        try {
            bool check = (urlcheck(dataGridView.Rows[i].Cells[2].Value.ToString()));
            if (check == true)
                ExecuteQuery("");
            else
                ExecuteQuery("");
        }
        catch{ }
    });
