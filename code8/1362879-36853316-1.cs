    if (cell is FormGridCell)
    {
        (cell as FormGridCell).CellColor = Color.Green;
        cell.Style.BackColor = Color.Green;
    }
    else
    {
        cell.Style.BackColor = Color.Red;
    }
