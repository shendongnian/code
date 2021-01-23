    static void TowersIterative(uint number, char src, char dest, char alt)
    {
        var stack = new Stack<Move>();
        stack.Push(new Move(number, src, dest, alt));
        while (stack.Count != 0)
        {
            var move = stack.Pop();
            if (move.Number == 1)
                Console.WriteLine("Move one disc from {0} to {1}", move.Src, move.Dest);
            else
            {
                stack.Push(new Move(move.Number - 1, move.Alt, move.Dest, move.Src));
                stack.Push(new Move(1, move.Src, move.Dest, move.Alt));
                stack.Push(new Move(move.Number - 1, move.Src, move.Alt, move.Dest));
            }
        }
    }
