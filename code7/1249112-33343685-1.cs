    public bool IsMatch(string target, string part1, string part2)
    {
        if (target == "" && part1 == "" && part2 == "")
        {
            return true;
        }
        
        if (part1.Length > 0 && target[0] == part1[0])
        {
            if (IsMatch(target.Substring(1), part1.Substring(1), part2.Substring(0)))
            {
                return true;
            }
        }
        if (part2.Length > 0 && target[0] == part2[0])
        {
            if (IsMatch(target.Substring(1), part1.Substring(0), part2.Substring(1)))
            {
                return true;
            }
        }
        
        return false;
    }
