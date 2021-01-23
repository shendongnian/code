    int v2 = 0;
    foreach (var v   in medals)
    {
        string temp = v.ToLower();
        if(temp == "gold")
            v2 += 100;
        else if(temp == "silver")
            v2 += 75;
        else if(temp == "bronze")
            v2 += 50;
    }
    Console.WriteLine("Total is:" + v2.ToString());
