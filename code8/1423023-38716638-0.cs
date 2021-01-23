    string fileName = "";
    List<string> names = new List<string>();
    do
    {
        Console.WriteLine("Please enter the XML File you Wish to send");
        fileName = Console.ReadLine();
        Thread t = new Thread(new ParameterizedThreadStart(send));               
        threads.Add(t);
        names.Add(fileName);
    }
    while (fileName != "start"); 
    foreach (Thread t in threads)
    {
        t.Start(names[0]);
        names.RemoveAt(0);
    }
