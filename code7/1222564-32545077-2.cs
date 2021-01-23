    public static void Print(IEnumerable<OutputClass> elements, string indent="")
    {
    	foreach (OutputClass element in elements)
    	{
    		Console.WriteLine("{0}{1} {2}", indent, element.id, element.text);
    		Print(element.children, indent + "  ");
    	}
    }
