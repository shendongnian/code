        if (turn == 0) {
            if (count <= 0) {
                return "You Lose!";
            }
            else {
                Console.WriteLine("It is now your turn.");
                Console.WriteLine("Would you like to take 1, 2, or 3 pieces?");
                playerInput = Convert.ToInt32(Console.ReadLine());
                if (playerInput >= 4) {
                    Console.WriteLine("{0} is not a valid input.", playerInput);
                    OneRowNim(count, turn, prevPlayerInput);
                }
                else if (playerInput < 1) {
                    Console.WriteLine("{0} is not a valid input.", playerInput);
                    OneRowNim(count, turn, prevPlayerInput);
                }
                else {
                    newCount = count - playerInput;
                    Console.WriteLine("You have taken {0} pieces, there are {1} pieces remaining.", playerInput, newCount);
                    OneRowNim(newCount, 1, playerInput);
                }
                return "";
            }
        }
        if (turn == 1) {
            if (count <= 0) {
                return "You Win!";
            }
            else {
                Console.WriteLine("It is now the computer's turn.");
                CPUInput = 4 - prevPlayerInput;
                newCount = count - CPUInput;
                Console.WriteLine("The computer took {0} pieces. There are {1} pieces remaining.", CPUInput, newCount);
                OneRowNim(newCount, 0, prevPlayerInput);
            }
            return "";
        }
    
  
