    int atkchoice;
    do
    {
    	// repeat until input is a number
    	Console.WriteLine("Please input a number! ");
    } while (!int.TryParse(Console.ReadLine(), out atkchoice));
    
    Console.WriteLine("You entered {0}", atkchoice);
