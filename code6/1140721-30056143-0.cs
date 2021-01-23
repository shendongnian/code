         Console.WriteLine("--- Row ---"); // Print separator.
	    foreach (var item in row.ItemArray) // Loop over the items.
	    {
		Console.Write("Item: "); // Print label.
		Console.WriteLine(item); // Invokes ToString abstract method.
	    }
    }
