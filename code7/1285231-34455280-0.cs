	if(isF6)
	{
		ItemReference = Game.GetPlayerGrabbedRef();
		if(ItemReference != null)
		{
			itemValue = ItemReference.GetFormID();
			if (itemValue != 0)
			{
				bGotObject = true;
			}
		}
		
		// nothing else to do; the next block is for F7
		return;
	}
