    public static void branch(int seed, int level, int limit) {
        var levelSum = (int) Math.Pow(2, level) + 1;
            
		if (limit == level + 1) {
			Console.WriteLine("Seed {0} vs. Seed {1}", seed, levelSum - seed);
			return;
		}
		else if (seed % 2 == 1) {
            branch(seed, level + 1, limit);
            branch(levelSum - seed, level + 1, limit);
        }
        else {
            branch(levelSum - seed, level + 1, limit);
            branch(seed, level + 1, limit);
        }
    }
    var numberTeams = 16;	// must be a power of 2
    var limit = (int) (Math.Log(numberTeams, 2) + 1);
           
    for (int round = 1; round < limit; round++) {
        Console.WriteLine("Round #{0}", round);
        branch(1, 1, limit - round + 1);
        Console.WriteLine();
    }
