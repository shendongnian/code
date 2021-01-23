    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        var gridViewItemsToDelete = (IEnumerable<MyData>)GridView.DataSource;
    
        foreach (var idToDelete in gridViewItemsToDelete.Select(r=>r.ID))
        {
            // Delete the item by its ID
            // I don't know what you're using to access your database
        }
    
        // Save Changes if you didn't in the foreach loop...
    }
