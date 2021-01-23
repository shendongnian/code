    class Move
    {
        public readonly char _Src, _Alt, _Dest;
        public readonly uint _Number;
        public Move(uint number, char src, char dest, char alt)
        {
            _Number = number;
            _Src = src;
            _Alt = alt;
            _Dest = dest;
        }
    }
    public static class Hanoi
    {
        static void TowersIterative(uint number, char src, char dest, char alt)
        {
            Stack<Move> _Stack = new Stack<Move>();
            _Stack.Push(new Move(number, src, dest, alt));
            TowersIterative(_Stack);
        }
        private static void TowersIterative(Stack<Move> _Stack)
        {
            while (_Stack.Count != 0)
            {
                var move = _Stack.Pop();
                if (move.Number == 1)
                    Console.WriteLine("Move one disc from {0} to {1}", move.Src, move.Dest);
                else
                {
    //              _Stack.Push(new Move(number - 1, alt, dest, src));
                    _Stack.Push(new Move(move.Number - 1, move.Alt, move.Dest, move.Src));
    //              _Stack.Push(new Move(1, src, dest, alt));
                    _Stack.Push(new Move(1, move.Src, move.Dest, move.Alt));
    //              _Stack.Push(new Move(number - 1, src, alt, dest));
                    _Stack.Push(new Move(move.Number - 1, move.Src, move.Alt, move.Dest));
                }
            }
        }
    }
