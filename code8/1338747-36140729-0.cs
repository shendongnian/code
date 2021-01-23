        decimal wantedSqrt = Decimal.Parse(input.text); //Takes the number from the textbox, and converts it to an int.
        Random rnd = new Random(); //We're going to pick a random number.
        decimal guess = rnd.Next(1, 100); //Pick a number between 1-100.
        for (int i = 0; i <10; i++)
        {
        decimal divHolder = wantedSqrt / guess; //Divide.
         guess = (guess + divHolder) / 2; //Average.
         //Make the average our new guess.
        Console.WriteLine(guess); //Seems like all it does is write the number 10 times.
        }
        string wantedSqrtString = wantedSqrt.ToString();
        Console.WriteLine(wantedSqrtString);
