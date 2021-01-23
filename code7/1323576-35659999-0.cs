    // Read the file and display next three lines
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\file.txt");
    string line;
    int lineCnt = 3;
    while((line = file.ReadLine()) != null)
    {
        if (line.Contains(myID) & !bGet) 
        {
            bool bGet = true;
        }
        if (bGet && lineCnt > 0) 
        {
            bool bGet = true;
            Console.WriteLine (line);
            lineCnt--;
        }
        if(lineCnt == 0) {break;}
    }
    file.Close();
    
    // Suspend the screen.
    Console.ReadLine();
