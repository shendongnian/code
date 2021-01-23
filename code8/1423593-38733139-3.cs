       // Bind keys to vocabulary and actions, all in high-signal code
       private static keyActions = new Dictionary<char, Action<KeyActionResult>> {
          ['p'] = KeepLoopingAfter(() =>  Console.WriteLine("You pressed 'p'!")),
          ['d'] = KeepLoopingAfter(DoSomethingComplicated),
          ['q'] = Quit(),
          ['x'] = QuitAfter(() => Console.WriteLine("Delete, then quit!"))
       }
          .AsReadOnly();
       
       // Run the main decision loop
       public static void Main() {
          bool shouldQuit;
          do {
             ConsoleKeyInfo keyInfo = Console.ReadKey(true);
             Action action;
             if (keyActions.TryGetValue(keyInfo.KeyChar, out action)) {
                shouldQuit = action().ShouldQuit;
             } else {
                shouldQuit = false;
             }
          } while (!shouldQuit)
       }
    }
