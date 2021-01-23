    public void PopulateControls()
    {
        var newGrid = new DispGrid();
        for (var i = 0; i < 1000; i++)
        {
            DispCombo newcombo = new DispCombo();
            newGrid.Children.Add(newcombo);
        }
        this.Content = newGrid;
    }
 
