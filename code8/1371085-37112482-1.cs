    private void Grid_ClickCellButton(object sender, ClickCellEventArgs e)
    {
        // Check if the click happens on the required column
        if (e.Cell.Column.Key == "Draw Lines")
        {
            ... your code ...
        }
    }
