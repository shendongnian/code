    Class3 c = new Class3();
    actionMeathod = c.TestJob3;
    regHandler.RegisterJob(actionMeathod, "Test3", 5000, true);
    // Add this line.
    Console.WriteLine(object.ReferenceEquals(c, actionMeathod.Target));
