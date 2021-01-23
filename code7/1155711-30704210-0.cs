    public IEnumerable<People> Search(string query, int maxResults = 20)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new List<People>();
        }
        IEnumerable<People> results;
        var split = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length > 1)
        {
            var firstName = split[0];
            var lastName = string.Join(" ", split.Skip(1));
            results = PeopleRepository.Where(x => 
                x.FirstName.StartsWith(firstName, StringComparison.OrdinalIgnoreCase) &&
                x.LastName.StartsWith(lastName, StringComparison.OrdinalIgnoreCase));
        }
        else
        {
            var search = split[0];
            results = PeopleRepository.Where(x => 
                x.FirstName.StartsWith(search, StringComparison.OrdinalIgnoreCase) ||
                x.LastName.StartsWith(search, StringComparison.OrdinalIgnoreCase));
        }
        return results.Take(maxResults);
    }
