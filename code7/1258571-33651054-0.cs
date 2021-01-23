      var actionBlock = new ActionBlock<int>(n => Console.WriteLine(n));
     
                 for (int i = 0; i < 10; i++) {
                     actionBlock.Post(i);
                 }
     
                 Console.WriteLine("Done");
