    string firstChoice = "getInputFromUser....";
    var isCorrectInput = false;
    do
    {
        if (firstChoice == "rudely")
        {
            isCorrectInput = true; //stop further loop iteration
            assholeFactor++;
            .....
        }
        else if 
            ... //set isCorrectInput as well
        else
        {
            //if input didn't match options, continue loop
            Console.WriteLine("That wasn't an option. Enter again...");
            firstChoice = Console.ReadneLine(); //
        }
    } while(!isCorrectInput);
