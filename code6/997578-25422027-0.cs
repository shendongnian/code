    private void Row_MouseLeave(object sender, MouseEventArgs args)
    {
        DataGridRow dataGridRow = sender as DataGridRow;
        if (dataGridRow.Item is YourClass)
        {
            YourClass yourItem = dataGridRow.Item as YourClass;
        }
        else if (dataGridRow.Item is MS.Internal.NamedObject)
        {
            // Item is new placeholder
        }
    }
