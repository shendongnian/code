       public Name[] FilterAddress(Name name)
        {
            return name.Where(x => string.IsNullOrEmpty(x.Addresses))
                                    .Select(x => x.Name)
                                    .ToArray();
        }
