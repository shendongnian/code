    int counter = 0;
    string line;
    
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.html");
    while((line = file.ReadLine()) != null)
    {
        if ( line.Contains("Subtotal") )
        {
            Console.WriteLine (counter.ToString() + ": " + line);
        }
    
       counter++;
    }
    
    file.Close();
