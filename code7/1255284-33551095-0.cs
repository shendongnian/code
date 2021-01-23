        foreach (var dup in pairs)
        {
            var toRemove = pairs.FirstOrDefault(o => o.Book1.Id == dup.Book2.Id
                                                       && o.Book2.Id == dup.Book1.Id
                                                       && o.Book1.Id > o.Book2.Id);
            if (toRemove != null)
                tempList.Remove(toRemove);
        }
