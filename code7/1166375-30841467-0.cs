    private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
        if (e.ColumnIndex == oneOfYourButtonColumnIndices && cell is DataGridViewCell)
        {
            Console.WriteLine(cell.Value.ToString());
            // do things that depend on the button:
            // if (cell.Value == "Conquer")  doConquer(..);
            // else (cell.Value == "Command")  doCommand(..);
            // ..
        }
    }
