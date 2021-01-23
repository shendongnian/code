    for (int i = 0; i < 6; i++)
    {
      var j = i;
      var t01 = Task.Factory.StartNew(() => Console.WriteLine("in loop: i = {0}", j));
    }
