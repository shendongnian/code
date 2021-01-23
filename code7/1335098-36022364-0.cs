    int total = 0;
    double avg;
    int parsedScore;
    //this bool will tell us if the data entered is valid
    bool isValid;
    int[] score = new int[8];
    string inValue;
    // prompt user for initial values
    for (int i = 0; i < score.Length; i++)
        {
            Console.Write("Please enter homework score [0 to 10] (-99 to exit): \n", i + 0);
            inValue = Console.ReadLine();
            //here we check that the data entered is valid and set our bool to the result
           isValid = int.TryParse(inValue, out parsedScore);
            if (isValid && parsedScore == -99) //check first if it is -99 and then exit if need be.
            {
                System.Environment.Exit(0);
            }
            //if it is not valid we are going to prompt them to re-enter their number 
            if(!isValid || (parsedScore < 0 && parsedScore > 10))
            {
                Console.WriteLine("Integer not entered or {0}, is not between 0 and 10.", inValue);
                i--; //we decrement i in order to let them re-enter at this index
            }
            else
            {
                //valid number, do logic here.
            }
