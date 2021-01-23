    for(int y = 0; y < boxes.length; y++)
    {
        //print line
        Console.Write("|")
        for(int x = 0; x < boxes[0].length; x++)
        {
            //Show char at that spot
            Console.Write("{0}|", boxes[y][x]);
        }
        //procede to next line
        Console.WriteLine();
    }
