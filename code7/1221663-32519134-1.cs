	buttonUpdateImage.Enabled = false; // disable button
	
	var tasks = cellsListView.CheckedItems.Cast<OLVListItem>()
										  .Select(async item => 
	{
		Cell cell = (Cell)(item.RowObject);
		await ProcessUtils.RunProcessAsync("path");
		cell.Status = 0;
	});
	await Task.WhenAll(tasks);
	buttonUpdateImage.Enabled = true;
