    int numbWrong = 0; //change
    for (int i = 0; i < myWord.Length; i++)
    {
        //if the user guessed right, replace the correct dash and display to the user
        if (myWord[i] == input)
        {
            count++; //update the count
            a[i] = input;  //if guess is correct, dash is replaced by what the user used as input
    
            //show the new dash array mixed with correct guesses
            for (int j = 0; j < a.Length; j++)
            {
                Console.Write(a[j] + " ");
            }
        }
        else
        {
            numbWrong += 1;
        }
    }
