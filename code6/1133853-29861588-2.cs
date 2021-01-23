    var machine = new StateMachine();
    while (!machine.IsFinished())
    {
        Console.WriteLine("Input a number from 1 to 3, but don't repeat a number you've input previously");
        var input = Console.ReadKey();
        Console.WriteLine();
        if (validInput.Contains(input.KeyChar)) {
            var newState = machine.TryTransition(input.KeyChar.ToString());
            if (newState == machine.Forbidden) {
                Console.WriteLine("You've input that before, try again!");
            } else {
                Console.WriteLine(newState.StateOutput);
            }
            Console.WriteLine("");
        }
    }
