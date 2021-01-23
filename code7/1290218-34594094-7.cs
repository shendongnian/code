    int number;
    if (!Int32.TryParse(Console.ReadLine(), out number))
    {
        // parse failed ("number" is now 0), display message to user
        Console.WriteLine("This only works with numbers!");
        // start the next iteration of the loop, prompting the user again
        // (otherwise, the number comparison runs, telling the user their guess is too small)
        continue;
    }
    if (number < gameNumber)
