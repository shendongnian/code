    var tasks = test.Select(i => TestIt(i)).ToList();
    bool found = false;
    while (tasks.Count != 0)
    {
      var completed = await Task.WhenAny(tasks);
      tasks.Remove(completed);
      if (await completed)
      {
        found = true;
        break;
      }
    }
    if (found)
      Console.WriteLine("Contains numbers > 3");
    else
      Console.WriteLine("Contains numbers <= 3");
