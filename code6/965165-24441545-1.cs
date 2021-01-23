    async Task<bool> CheckAll()
    {
        foreach(var checker in checkers)
        {
            if (!await checker.Check())
            {
                return false;
            }
        }
        return true;
    }
