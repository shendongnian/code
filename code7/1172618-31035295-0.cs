    using System.IO;
    int counter = 0;
    string line;
    
    // Read the file and display it line by line.
    StreamReader file = new StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       Console.WriteLine (line);
       counter++;
    }
    
    file.Close();
    
    // Suspend the screen.
    Console.ReadLine();
