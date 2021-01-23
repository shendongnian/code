	public List<Item> items;
	public List<Item> finalItems;
	
    #region Unity
    void Start ()
    {
		Screen.lockCursor = true;
        // Do a while loop until finalItems contains 5 Items
        while (finalItems.Count < 5) {
			Item newItem = items[Random.Range(0, items.Count)];
			if (!finalItems.Contains(newItem)) {
				finalItems.Add(newItem);
			}
		}
	}
