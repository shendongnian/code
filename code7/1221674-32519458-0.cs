    // Note this object.
    Barrier b = new Barrier(cellsListView.CheckedItems.Count, () => {
       // enable the button here
       buttonUpdateImage.Enabled = true;
    });
    buttonUpdateImage.Enabled = false; // disable button
    foreach (OLVListItem item in cellsListView.CheckedItems)
    {
        Cell c = (Cell)(item.RowObject);
        var task = Task.Factory.StartNew(() =>
        {
              Process p = new Process();
                ...
              p.Start();
              p.WaitForExit();             
         });
         task.ContinueWith(t => {
           c.Status = 0;
           b.SignalAndWait();
         });
    }
       
