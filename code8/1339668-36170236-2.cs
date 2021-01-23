        for (int index = 0; index < hoursArray.Count; index++)
        {
            Console.WriteLine(hoursArray[index]);
        }
        //Calculate
        for (int index = 0; index < hoursArray.Count; index++)
        {
            total = total + hoursArray[index];
            if (hoursArray[index] < low)
            {
                low = hoursArray[index];
            }
            if (hoursArray[index] > high)
            {
                high = hoursArray[index];
            }
        }
        avarage = (double)total / hoursArray.Count;
        //Output
        Console.WriteLine("Total hours parked: " + total);
        Console.WriteLine("Avarage hours parked: " + avarage.ToString("N2"));
        Console.WriteLine("Lowest number = " + low);
        Console.WriteLine("Lowest number = " + high);
        Console.ReadKey();
