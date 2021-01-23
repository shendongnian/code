    Console.WriteLine("Before Output");
    for (int i = 0; i < 10; i++)
         {
              int currentLine = Console.CursorTop;
              Console.WriteLine("i is {0}", i);
              Thread.Sleep(500);
              Console.SetCursorPosition(0, currentLine);
         }
    Console.WriteLine("After");
