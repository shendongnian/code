    for (int 1 = 0; i < 10; i++)
    {
        Console.Write("Please enter a letter to guess: ");
        char guess = char.Parse(Console.ReadLine());
        
        if(word.Contains(guess))//checks if the word is is the array word
        {
            //the guess was correct.
            Console.WriteLine("Your guess is correct.");
            guessed[index] = guess;
            index++;
        }
        else
        {
            //the guess was wrong.
            console.WriteLine("Your guess is incorrect.");
            ....
        }
    }
