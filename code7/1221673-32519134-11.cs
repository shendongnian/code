	buttonUpdateImage.Enabled = false; // disable button
	
	var tasks = cellsListView.CheckedItems.Cast<OLVListItem>()
										  .Select(async item => 
	{
		Cell cell = (Cell)item.RowObject;
		
		var process = new Process();
		await process.RunProcessAsync("path");
		
		cell.Status = 0;
	});
	await Task.WhenAll(tasks);
	buttonUpdateImage.Enabled = true;
