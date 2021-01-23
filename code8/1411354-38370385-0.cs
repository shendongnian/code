    private async void buttonStart_Click(object sender, EventArgs e)
    {
        var cells = objectListView.CheckedObjects;
        if(cells != null)
        {
            await Task.Run( () => Parallel.ForEach( cells, c => ... ) );
        }
    }
