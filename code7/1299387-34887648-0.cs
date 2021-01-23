            string userValue = Console.ReadLine();
            string message = "";
            Console.WriteLine("Card 1, 2, or, 3?");
            userValue = Console.ReadLine(); // Assign
            while (userValue != "1" && userValue != "2" && userValue != "3")
            {
                message = "try again. Card 1, 2, or, 3?";
                Console.WriteLine(message);
                userValue = Console.ReadLine(); // Assign
            }
            if (userValue == "1")
            {
                message = "You win a Coke";
            }
            else if (userValue == "2")
            {
                message = "You win a Diet Coke";
            }
            else if (userValue == "3")
            {
                message = "You win a Apple Juice";
            }
            Console.WriteLine(message);
            Console.ReadLine();
