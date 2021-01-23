    public class Program
    {
    	public static void Main()
    	{		
    		  string SizeName = "";
            double SizeCost = 0;
            string ToppingName = "";
            double ToppingCost = 0;
            double TotalCost =0;
            double Tax = 0;
            double TotalWithTax = 0;
    
            //Print a greeting message.
            Console.WriteLine("Welcome to the Central Pizza Parlor!");
    
            //Ask if the customer would like to order a pizza.
            Console.WriteLine("Would you like to order a pizza today? Enter y for Yes or n for No.");
            string Order = Console.ReadLine();
    
            //Start the order if answer is Yes, if not, then exit the program.
            if (Order == "y")
            {
                //Continue with order.
                Console.WriteLine("Great! Let's get started, please pick the size of your pizza:");
                Console.WriteLine("1 - Small  $5.00");
                Console.WriteLine("2 - Medium $7.00");
                Console.WriteLine("3 - Large  $9.00");
    
                //Get pizza size for order.
                Console.WriteLine("Please enter the number for the pizza size you would like.");
                string sizeAsAString = Console.ReadLine();
                int size = Convert.ToInt32(sizeAsAString);
    
    
                //Use If Else statement to set the variable value for SizeCost.
                if (size == 1)
                {
                    SizeCost = 5.0;
                    SizeName = ("Small");
                }
                else if (size == 2)
                {
                    SizeCost = 7.0;
                    SizeName = ("Medium");
                }
                else if (size == 3)
                {
                    SizeCost = 9.0;
                    SizeName = ("Large");
                }
    
                //Have Customer select toppings.
                Console.WriteLine("Please select which topping you would like on your pizza.");
                ;
                Console.WriteLine("1 - Pepperoni     $2.00");
                Console.WriteLine("2 - Ham           $2.00");
                Console.WriteLine("3 - Onions        $1.00");
                Console.WriteLine("4 - Mushrooms     $1.00");
                Console.WriteLine("5 - Green Peppers $1.00");
    
                Console.WriteLine("Please enter the number for the corresponding topping you would like.");
                string toppingAsAString = Console.ReadLine();
                int topping = Convert.ToInt32(toppingAsAString);
    
    
                //Use If Else statement to set the variable value for ToppingCost.
                if (topping == 1) 
                {
                    ToppingCost = 2.0;
                    ToppingName = ("Pepperoni");
                }
                else if (topping == 2)
                {
                    ToppingCost = 2.0;
                    ToppingName = ("Ham");
                }
                else if (topping == 3)
                {
                    ToppingCost = 1.0;
                    ToppingName = ("Onions");
                }
                else if (topping == 4)
                {
                    ToppingCost = 1.0;
                    ToppingName = ("Mushrooms");
                }
                else if (topping == 5)
                {
                    ToppingCost = 1.0;
                    ToppingName = "Green Peppers";
                }
    			
    			 TotalCost = (SizeCost + ToppingCost);
            	Tax = (TotalCost*0.085);
    			TotalWithTax = (TotalCost + Tax);
    			
                //Display order details.
                Console.WriteLine("Here are the details for your order.");
                Console.WriteLine("Thank you for your business!");
                Console.WriteLine("You can pick up your pizza in 25 minutes!");
    
                //Show current time of order.
                DateTime now = DateTime.Now;
                Console.WriteLine("Time Ordered: "+now+" ");
    
                //Show Current time of order with additional 25 minutes for pickup.
                DateTime pickup = DateTime.Now.AddMinutes(25);
                Console.WriteLine("Pick Up At: "+pickup+" ");
    
                //Output Pizza Size.
                Console.WriteLine("Size: " +SizeName+ "  ");
    
                //OutPut Topping name.
                Console.WriteLine("Topping: " +ToppingName+ " ");
    
                Console.WriteLine("---------------");
    
                //Output total price of size and topping chosen.
                Console.WriteLine("Pizza Price: $ "+TotalCost+" ");
    
                //Output tax amount.
                Console.WriteLine("Tax: $" +Tax+ " ");
    
                //Output total price with tax.
                Console.WriteLine("Total Price: $" +TotalWithTax+ "  ");
    
    
            }
            else 
            {
                //Exit the program because the customer does not want to order a pizza.
                Console.WriteLine("Alright, have a great day!");
            }
    
            Console.ReadLine();
    
    
        }
    }
