    var listA = new[] { 1, 2, 3 };
	var listB = new[] { "a", "b", "c" };
	var listC = new[] { 5f, 6f, 7f };
	foreach(var n in Iterator.Enumerate(listA, listB, listC))
	{
		foreach(var obj in n)
		{
			Console.Write(obj.ToString() + ", ");
		}
		Console.WriteLine();
	}
