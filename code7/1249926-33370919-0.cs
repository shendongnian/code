    var newArray = new int[7];
    Console.WriteLine("Hello! Please enter 7 numbers between 1-25, press ENTER after each number. ");
    for (var i = 0; i <= newArray.Length - 1; i++)
    {
    	int number;
    	while (!int.TryParse(Console.ReadLine(), out number))
    	{
    		Console.WriteLine("You may only enter numbers!");
    	}
    
    	newArray[i] = Convert.ToInt32(number);
    }
    Console.WriteLine("You entered the following numbers: ");
    foreach (var t in newArray)
    {
    	Console.WriteLine(t);
    }
