    // General definition
    A Fix<A>(Func<Func<A>,A> f) {
      return f(() => Fix(f));
    }
    
    // Special definition for void functions
    void Fix(Action<Action> f) {
      f(() => Fix(f));
    }
    
    void Menu(Action menu) {
      if (i < 2) {
        Console.WriteLine();
      }
      else {
        Console.WriteLine("Something Went Wrong!");
        Console.WriteLine("Something went wrong!");
        menu();
      }
    }
    
    Fix(Menu);
