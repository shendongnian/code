	public static void Rotate<T>(this Queue<T> items, int places)
    {
		for (int i = 0; i < places; i++)
			items.Enqueue(items.Dequeue());
    }
