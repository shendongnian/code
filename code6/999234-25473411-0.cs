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
            TowersIterative(number, _Stack);
        }
        private static void TowersIterative(uint number, Stack<Move> _Stack)
        {
            while (_Stack.Count != 0)
            {
                var move = _Stack.Pop();
                if (number == 1)
                    Console.WriteLine("Move one disc from {0} to {1}", move._Src, move._Dest);
                else
                {
    //              _Stack.Push(new Move(number - 1, alt, dest, src));
                    _Stack.Push(new Move(move._Number - 1, move._Alt, move._Dest, move._Src));
    //              _Stack.Push(new Move(1, src, dest, alt));
                    _Stack.Push(new Move(1, move._Src, move._Dest, move._Alt));
    //              _Stack.Push(new Move(number - 1, src, alt, dest));
                    _Stack.Push(new Move(move._Number - 1, move._Src, move._Alt, move._Dest));
                }
            }
        }
    }
