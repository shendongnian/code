    public bool IsMatch(string target, string part1, string part2)
    {
        if (target.Length != part1.Length + part2.Length)
        {
            return false;
        }
        
        int iPart1 = 0, iPart2 = 0;
        
        for (var i = 0; i < target.Length; ++i)
        {
            if (iPart1 < part1.Length && target[i] == part1[iPart1])
            {
                ++iPart1;
                continue;
            }
            if (iPart2 < part2.Length && target[i] == part2[iPart2])
            {
                ++iPart2;
                continue;
            }
            
            return false;
        }
        
        return true;
    }
