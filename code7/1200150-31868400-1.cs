    using (StreamReader myFile = File.OpenText(fileResponse))
    {
        int count = 0; //counts the number of times wordResponse is found.
        int lineNumber = 0;
        while(!myFile.EndOfStream)
        {
            string line = myFile.ReadLine();
            lineNumber++;
            int position = line.IndexOf(wordResponse);
            if (position != -1) {
                count++;
                Console.WriteLine("Match #{0} {1}:{2}", count, lineNumber, line)  
            }
    }
         
    if (count == 0) {
        Console.WriteLine("your word was not found!");
    } else {
        Console.WriteLine("Your word was found " + count + " times!");
    }
    Console.ReadLine();
