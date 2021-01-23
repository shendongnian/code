    public void Validate(List<Row> rows)
    {
        var sameCarColorMoreThanOne = rows.GroupBy(ks => new { ks.Car, ks.Color })
                                          .Select(s => new { s.Key, Count = s.Count() })
                                          .Where(p => p.Count > 1);
        if (sameCarColorMoreThanOne.Any())
            throw new ExceptionWithListOfDuplicateKeys(sameCarColorMoreThanOne.Select(s => new Tuple<string, string>(s.Key.Car, s.Key.Color)));
    }
