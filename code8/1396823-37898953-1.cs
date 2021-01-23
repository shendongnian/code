    for(int i = 0; i < mylist.Count; i++)
    {
        if (mylist[i] % 2 == 0)
        {
            mylist.RemoveAt(i);
            i--;
            continue;
        }
    
        Console.WriteLine(mylist[i]);
    }
