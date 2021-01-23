    Console.WriteLine("Enter five single digit numbers");
    List<int> list = new List<int>();
    do
    {
        var keyNumber = (int)Console.ReadKey(true).KeyChar;
        if (keyNumber >= 48 && keyNumber <= 57)
        {
            Console.WriteLine("Your input number is:" + (char)keyNumber);
            list.Add(keyNumber);
        }
        else
        {
            Console.WriteLine("Sorry, but please enter single digit numbers!");
        }
    }
    while (list.Count < 5);
    var resultFirst = list[0] - list[1];
    var resultSecond = list[2] - list[3];
    var resultThird = resultFirst + resultSecond;
    var resultFinal = resultThird + list[4];
    Console.WriteLine("Answer: {0}", resultFinal);
    Console.WriteLine("Press any button to close");
    Console.ReadLine();
