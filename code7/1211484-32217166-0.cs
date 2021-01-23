	public T GetItem<T>(ICollection<T> input, int n) {
		return input.ElementAt(n);
    }
	var items = new List<int>() { 1, 2, 3 };
	int secondItem = GetItem(input, 2); // int is inferred  based on generic type of collection item
