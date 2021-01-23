        if (orderBy != null)
        {
            return maxResults.HasValue() ? orderBy(query).Take((int)maxResults).ToList() : orderBy(query).ToList();
        }
        else
        {
            return maxResults.HasValue() ? query.take((int)maxResults).ToList() : query.ToList();
        }
