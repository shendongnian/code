    string line;
    int counter = 0;
    
    Console.WriteLine("Enter a word to search for: ");
    string userText = Console.ReadLine() + " ";
    
    string file = "NewTextFile.txt";
    StreamReader myFile = new StreamReader(file);
    
    int found = 0;
    
    while((line = myFile.ReadLine()) != null)
    {
        line = line.ToUpper();
        counter++;
        if (line.Contains(userText.ToUpper()))
        {
            Console.WriteLine("Found on line number: {0}", counter);
            Console.WriteLine(line.Substring(line.IndexOf(userText)+1,userText.Length));
            found++;
        }
     }
     Console.WriteLine("A total of {0} occurences found", found);
     Console.ReadLine();
