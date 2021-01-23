    var actionBlock = new ActionBlock<int>(i => TryMe(i));
    foreach (var num in Enumerable.Range(0, 100))
    {
          actionBlock.Post(num);
    }
    try
    {
         await actionBlock.Completion();
    }
    catch (Exception e)
    {
         // Block finished prematurely, handle exception.
    }
