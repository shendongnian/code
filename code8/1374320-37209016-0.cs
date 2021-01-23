	try
	{
		groups.BeginUpdate();
		
		List<object> dataFromDB = ...;
		// Znamy aktualną kolejność grup
		List<BaseLayoutItem> currentOrder = groups.Items.Cast<object>().Where(c => c is BaseLayoutItem).Cast<BaseLayoutItem>().ToList();
		
		// Sort as visibile in form
		currentOrder.Sort((x, y) => System.Collections.Comparer.Default.Compare(x.Location.Y, y.Location.Y));
		
		// Save old visibilities
		LayoutVisibility[] allVisibilities = currentOrder.Select(x => x.Visibility).ToArray();
		currentOrder.ForEach(x => x.Visibility = LayoutVisibility.Always);
		List<BaseLayoutItem> requiredOrder = ...; // prepare required order
		// Make requiredOrder[0] topmost group
		// Move
		for (int i = 1; i < requiredOrder.Count; ++i)
		{
			BaseLayoutItem relative = groups.Items.FindByName(requiredOrder[i - 1].Name);
			BaseLayoutItem toMove = groups.Items.FindByName(requiredOrder[i].Name);
			toMove.Move(relative, InsertType.Bottom);
		}
		// Restore visibilities
		for (int i = 0; i < currentOrder.Count; ++i)
		{
			currentOrder[i].Visibility = allVisibilities[i];
		}
		
	}
	finally
	{
		groups.EndUpdate();
	}
