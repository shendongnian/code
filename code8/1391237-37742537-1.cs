    private sealed class DisplayClass {
         public int i;
         public Action getAct() {
            return () => Console.WriteLine(i);
         }
         public void Action() {
            Console.WriteLine(i);
         }
      }
