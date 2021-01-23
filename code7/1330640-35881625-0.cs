    public enum ThingsToDo
    {
        // use powers of 2!
        DoThis          = 1 << 0,
        DoThat          = 1 << 1,
        WhileYouAreAtIt = 1 << 2,
        AndFinally      = 1 << 3
    }
    class Program
    {
        static void Main(string[] args)
        {
            var First = ThingsToDo.DoThat | ThingsToDo.DoThis;
            var Next = ThingsToDo.WhileYouAreAtIt | ThingsToDo.AndFinally;
            // ...
            if ((First & ThingsToDo.DoThis) == ThingsToDo.DoThis) {
                // do this 
            }
            if ((Next & ThingsToDo.WhileYouAreAtIt) == ThingsToDo.WhileYouAreAtIt)
            {
                // do while you are at it
            }
        }
    }
