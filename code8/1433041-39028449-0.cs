    for (int i = 0; i < completeInfoMatches.Count; i++) 
    {
        if (!(databaseGridView.Columns
                  .Cast<DataGridViewColumn>()
                  .Any(x => x.HeaderText == e.Node.Parent.Text))) 
        {
            Console.WriteLine(e.Node.Parent.Text);
            databaseGridView.Columns.Add("column" + i, e.Node.Parent.Text);
        }
    }
