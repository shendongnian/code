    list.Sort((x, y) =>
    {
        if (x.Id == 0)
        {
            return -1;
        }
        if (y.Id == 0)
        {
            return 1;
        }
        return x.Group.Name.CompareTo(y.Group.Name);
    });
