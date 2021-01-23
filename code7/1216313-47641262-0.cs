    List<string> simpleList = new List<string> { "Alpha", "Bravo", "Charlie", "Delta", "Echo" }; //Dummy data source
            Console.WriteLine("Enter a call sign to find in the list. Press X to exit: "); //Prompt
            string callSign;
            string exitKey = "x";
            while ((callSign = Console.ReadLine()) != exitKey.ToLower()) { //This is where the "Magic" happens
                if (simpleList.Contains(callSign)) {
                    Console.WriteLine($"\"{callSign}\" exists in our simple list");//Output should the list contain our entry
                    Console.WriteLine(""); //Not really relevant, just needed to added spacing between input and output
                }
                else {
                    Console.WriteLine($"\"{callSign}\" does not exist in our simple list"); //Output should the list not contain our entry
                }
                Console.WriteLine("");
                Console.WriteLine("Enter a call sign to find in the list. Press X to exit: ");//Prompt
            }
