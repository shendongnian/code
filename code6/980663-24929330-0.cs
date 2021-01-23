    public Statistic Add(Statistic statistic)
    {
        // _context.Statistic.Include(w => w.User).Load();
        UserKeyType key;
        if (_userKeyLookup.Contains(statistic.UserId))
        {
            key = _userKeyLookup[statistic.UserId];
        }
        else
        {
            key = _context.Users.Where(u => u.Id == statistic.UserId).Select(u => u.Key).FirstOrDefault();
            _userKeyLookup.Add(statistic.UserId, key);
        }
        statistic.User = new User { Id = statistic.UserId, Key = key };
        
        // similar code for api..
        // _context.Statistic.Include(p => p.Api).Load();
        _context.Statistic.Add(statistic);
        return statistic;
    }
