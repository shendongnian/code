    // I need the results of Task1 to calculate StringList and to run Task2
    var task1Result = await Task1(ct);
    var stringList = CalculateStringList(task1Result);
    // Task2, Task3 and Task4 can all run concurrently
    var task2 = Task2(ct, stringList);
    var task3 = Task3(ct);
    var task4 = Task4(ct);
    await Task.WhenAll(task2, task3, task4);
    // I need the return values from all of the above for later method calls
    var task2Result = await task2;
    var task3Result = await task3;
    var task4Result = await task4;
    // Once these are run, I use their results to run Task5
    await Task5(ct, task2Result, task3Result, task4Result);
    // Once Task5 is run, I use all the results in running Task6
    await Task6(ct, task2Result, task1Result);
