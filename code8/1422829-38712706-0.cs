        static void Main(String[] args)
        {
            string input =
    @"3 1
    11 3
    12 2
    13 1";
            StringReader reader = new StringReader(input);
    
            // helper function for reading lines
            Func<string, int[]> LineToIntArray = (line) => Array.ConvertAll(line.Split(' '), Int32.Parse);
    
            int[] line1 = LineToIntArray(reader.ReadLine());
            int N = line1[0], // # of mines
                K = line1[1]; // # of pickup locations
    
            // Populate mine info
            List<Mine> mines = new List<Mine>();
            for (int i = 0; i < N; ++i)
            {
                int[] line = LineToIntArray(reader.ReadLine());
                mines.Add(new Mine() { Distance = line[0], Gold = line[1] });
            }
    
            // helper function for cost of a move
            Func<Tuple<Mine, Mine>, int> MoveCost = (tuple) =>
                Math.Abs(tuple.Item1.Distance - tuple.Item2.Distance) * tuple.Item1.Gold;
    
            // all move combinations
            var moves = (from m1 in mines
                        from m2 in mines
                        where !m1.Equals(m2)
                        select Tuple.Create(m1, m2)).ToList();
    
            int sum = 0, // running total of move costs
                unconsolidatedCount = N;
            while (moves.Count > 0 && unconsolidatedCount != K)
            {
                var move = moves.Aggregate((a, m) => MoveCost(a) < MoveCost(m) ? a : m);
    
                sum += MoveCost(move); // add this consolidation to the total cost
                move.Item2.Gold += move.Item1.Gold;
                moves.RemoveAll(m => m.Item1 == move.Item1 || m.Item2 == move.Item1);
                unconsolidatedCount--;    
            }
    
            Console.WriteLine("Moves: " + sum);
        }
