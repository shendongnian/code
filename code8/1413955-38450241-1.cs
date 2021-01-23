	public static void Shift(this Queue<int> items, int places)
    {
		for (int i = 0; i < places; i++)
			items.Enqueue(items.Dequeue());
    }
