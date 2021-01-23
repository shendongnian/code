    foreach (DateTime dt in dateTimes1)
    {   
        int currentHour = dt.Hour;             
        int dt1index = Array.FindIndex(dateTimes1, a => a == dt); //get the index of the current item in dateTimes1
        int dt2index = Array.FindIndex(dateTimes2, x => x.Hour == currentHour); //get the index of the item in dateTimes2 matching dateTimes1 hour field
    
        
        int lastHour = dateTimes2[dateTimes2.GetUpperBound(0)].Hour; //GetUpperBound(0) is the last index
    
        if (currentHour > lastHour)
        {
            Console.WriteLine("{0}, {1}", dt1index, dateTimes2.GetUpperBound(0));
        }
        else
        {
            Console.WriteLine("{0}, {1}", dt1index, dt2index);
        }             
        
    }
