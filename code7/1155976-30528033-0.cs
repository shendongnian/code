    public void DisplayGridViewSums(GridView gv)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            long sum = SumValuesInRow(row);
            Console.WriteLine("Sum of values in raw '{0}' is: {1}", row.RowIndex, sum);
        }
        for (int i=0; i<gv.Columns.Count;i++)
        {
            long sum = SumValuesInColumn(gv,i);
            Console.WriteLine("Sum of values in column '{0}' with header '{1}' is: {2}",i, gv.Columns[i].HeaderText, sum);
        }
        long totalsum = SumColumnsAndRowsInGridView(gv);
        Console.WriteLine("Sum of all cells in each row is: {0}", totalsum);
    }
    public long SumColumnsAndRowsInGridView(GridView gv)
    {
        long sum = 0;
        foreach (GridViewRow row in gv.Rows)
        {
            sum += SumValuesInRow(row);
        }
        return sum;
    }
    public long SumValuesInRow(GridViewRow row)
    {
        long sum = 0;
        foreach (TableCell cell in row.Cells)
        {
            sum += int.Parse(cell.Text);
        }
        return sum;
    }
    public long SumValuesInColumn(GridView gv, int columnIndx)
    {
        long sum = 0;
        foreach (GridViewRow row in gv.Rows)
        {
            sum += int.Parse(row.Cells[columnIndx].Text);
        }
        return sum;
    }
