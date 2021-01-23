    Task.Factory.StartNew(() => //This is important to make sure that the UI thread can return immediately and then be able to process UI update requests
    {
        Parallel.ForEach(dataGrid1.Rows.Cast<DataGridViewRow>(), row =>
        {
            // SOME CODES REMOVED FOR CLARITY
            string data1 = row.Cells[1].Value;
            var returnData = getHtml(data1); //expensive call
        
            Task.Factory.StartNew(() => row.Cells[2].Value = returnData,
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext()); //This will request a UI update on the UI thread and return immediately
        }); 
    });
