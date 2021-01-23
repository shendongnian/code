    //Used to track position of found numbers
    var currentPosition = 0;
    //Keeps the indexes 
    var foundIndexes = new List<int>();
    //Some dummy data
    int[] numbers = {1, 2, 3, 5, 2, 3, 3, 5, 7};
    for (var i = 0; i < numbers.Length; i++)
        {
           if (numbers[i] == value)
           {
               foundIndexes.Add(i);
           }
        }
    //can use the LINQ for each if you like it better (I do)
    foundIndexes.ForEach(index =>
    {
         Console.WriteLine("number is found At position " + index);
    });
