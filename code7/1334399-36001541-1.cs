    private void GeneratingColumnEvent(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        try
        {
            //Modify Columns names in Header, and apply proper String Format if needed
            // Collapse the ID column
            if (e.Column.Header.ToString() == "ID")
            { e.Column.Visibility = Visibility.Collapsed; }
            // Item
            else if (e.Column.Header.ToString() == "Item")
            { e.Column.Width = new DataGridLength(4.5, DataGridLengthUnitType.Star); }
            // Price
            if (e.Column.Header.ToString() == "Price")
            {
                e.Column.Header = "Px";
                (e.Column as DataGridTextColumn).Binding.StringFormat = "C2";
                e.Column.Width = new DataGridLength(1.7, DataGridLengthUnitType.Star);
            }
       }
        catch { }
    }
