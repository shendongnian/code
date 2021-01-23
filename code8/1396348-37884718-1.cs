    // This will group your rows using the values in ItemA and ItemB and map
    // each of the inner groupings to an array of integer values
    var groupedItems = items.GroupBy(i => new { i.ItemA, i.ItemB })	
			                .Select(g => g.Select(ig => ig.ToIntegerArray()))
							.ToList();
