    List<string> woorden = new List<string>();
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("txt.txt");
    while (!file.EndOfStream)
    {
       string woord = file.ReadLine();
       string[] words = woord.Split(' ') //This will take the line grabbed from the file and split the string at each space. Then it will add it to the array
       for (int i = 0; i < words.Count; i++) //loops through each element of the array
       {
          woorden.Add(words[i]); //Add each word on the array on to woorden list
       }
    }
    Console.WriteLine();
    file.Close();
    Console.ReadKey();
