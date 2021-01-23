        bool valid;
        do
        {
            valid = true;
            userChoice1 = Console.ReadLine();
            switch (userChoice1)
            {
                case "1":
                    msg = "\n\nYou have chosen the House Salad with Ranch Dressing. \nPress enter to continue.";
                    saladChoice = "House Salad with Ranch Dressing";
                    break;
                case "2":
                    msg = "\n\nYou have chosen the Caesar Salad. \nPress enter to continue. ";
                    saladChoice = "Caesar Salad";
                    break;
                default:
                    msg = "\n\nYou have chosen an invalid option. You should have selected  \n1 for the House Salad \nor \n2 for the Caesar Salad. ";
                    valid = false;
                    Console.Beep();
                    break;
            }
        } while (!valid);
