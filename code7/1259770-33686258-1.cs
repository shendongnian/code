	static void Main(string[] args)
	{
	   string[] toppings = { "cheese", "pepperoni", "green pepper", "onion", "mushroom" };
	   double[] price = { 1.30, 1.90, 1.80, 1.70, 1.60 };
	   Console.WriteLine("Choose a topping: cheese, pepperoni, green pepper, onion or mushroom");
	   Console.WriteLine("Please type the topping that you want - exactly as it appears above:");
	   string order = Console.ReadLine();
	   Console.WriteLine("\nYou chose: " + order);
	   int index = topping.IndexOf(order);
	   if (index == -1)
	   {
		   Console.WriteLine("The product " + order + " was not found, please try again!!!!!!\n");
		   Console.WriteLine("Hit any key to close"); Console.ReadKey(true);
		   return;
	   }
	   Console.WriteLine("The price of " + order + " is $" + price[index]);
	   Console.WriteLine("Hit any key to close"); 
       Console.ReadKey(true);
	}    
