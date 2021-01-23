    string input="201607";
	int integerPart=0;		
	if(int.TryParse(input.Substring(0,4),out integerPart))
	{
		Console.WriteLine("Integer value is {0}",integerPart);
	}
	else
	{
	    Console.WriteLine("Conversion Failed");
	}
	byte bytePart = byte.Parse(input.Substring(4));
	Console.WriteLine("Byte Part is {0}",bytePart);
