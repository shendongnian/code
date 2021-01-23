    DateTime initialTime = DateTime.Now;
    for (DateTime loopTime = initialTime; loopTime < initialTime.AddMinutes(2); loopTime = loopTime.AddSeconds(15))
    {
        Console.WriteLine(loopTime);
    }
