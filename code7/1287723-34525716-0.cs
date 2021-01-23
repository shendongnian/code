    enum Color { Black, Green, Red };
    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine();
    Color color;
    
    // Enum.TryParse will try to parse the user's input
    // and if it fails, it will return false and will ask from the user to 
    // enter a valid color.
	while (!Enum.TryParse(tempColor, out color))
	{
	    Console.Write("You should peak one color from Black, Green and Red.");
        tempColor = Console.ReadLine();
	}
