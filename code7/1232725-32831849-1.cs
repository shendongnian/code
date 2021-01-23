    public static List<List<Slots>> GetSlotGroups(List<Slots> slots)
    {
    	var slotGroups = new List<List<Slots>>();
    	using (var e = slots.OrderBy(slot => slot.StartTime).GetEnumerator())
    	{
    		List<Slots> currentGroup = null;
    		Slots lastSlot = null;
            while (e.MoveNext())
    		{
    			var currentSlot = e.Current;
    			if (lastSlot == null || currentSlot.StartTime.Date.Subtract(lastSlot.EndTime.Date).Days > 1)
    				slotGroups.Add(currentGroup = new List<Slots>());
    			currentGroup.Add(currentSlot);
    			lastSlot = currentSlot;
    		}
    	}
    	return slotGroups;
    }
