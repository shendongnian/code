    List<int> YourButtonColumnIndices = new List<int> {3,5,7};
    private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
        // check if we have hit a button cell..
        if (YourButtonColumnIndices .Contains(e.ColumnIndex) && cell is DataGridViewButtonCell )
        {
            Console.WriteLine(cell.Value.ToString());
            // do things that depend on the button:
            // if (cell.Value == "Conquer")  doConquer(..);
            // else (cell.Value == "Command")  doCommand(..);
            // ..
        }
    }
