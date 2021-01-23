    private void receiptView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (!_selectionChanged)
        {
            Console.WriteLine("Cleared.......");
            receiptView.ClearSelection(); // NOTE: Triggers SelectionChanged event.
            _selectionChanged = true;
        }
        else
        {
            Console.WriteLine("Highlighted...");
            _selectionChanged = false;
        }
    }
    private void receiptView_SelectionChanged(object sender, EventArgs e)
    {
        Console.WriteLine("Changed!");
        _selectionChanged = true;
    }
