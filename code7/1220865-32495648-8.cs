    string givenstring, outputString = "";
    int i, j = 0;
    string[] arr = new string[2];
    Console.WriteLine("Enter the string");
    givenstring = Console.ReadLine();
    i = (givenstring.Length) / 2;
    while (j < i)
    {
         outputString += givenstring[j];
         j++;
    }
    Console.Write("Input -> " + outputString + " ");//hello world
    arr[0] = outputString;
    outputString = string.Empty;
    while (i < givenstring.Length)
    {
        outputString += givenstring[i];
        i++;
    }
    arr[1] = outputString;
    Console.WriteLine(outputString);
    string reversed = arr.Aggregate((workingSentence, next) => next + " " + workingSentence);
    Console.WriteLine("output -> " + reversed);//world hello
    Console.WriteLine("output -> " + ReverseString(reversed));//olleh dlrow
    Console.ReadLine();
