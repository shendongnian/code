    bool workToDo = true;
    while(workToDo) {
        Console.WriteLine("Please choose your favorite beverage (and other text)");
        string input = Console.ReadLine();
       
        if (input == "1") {
            Console.WriteLine("Enjoy your Cola!");
        }
        // Your normal options go here and for the other inputs.
        else if(input == "exit") {
            workToDo = false;
        }
        else {
            Console.WriteLine("That is not a valid input! Try again!");
        }
