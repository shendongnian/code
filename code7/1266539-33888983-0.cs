    Task[] task = new Task[count];
    for (byte parameter = 1; parameter < 5; parameter++)
    {
        for (byte step = 0; step < xValues.Count; step++)
        {
            task[index] = AddMeasure(av, average, parameter, step, time, file);
        }
    }
    await Task.WhenAll(task);
