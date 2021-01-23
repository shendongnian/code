    IEnumerable<T> RotateLeft<T>(IEnumerable<T> list, int places)
    {
        return list.Skip(places).Concat(list.Take(places));
    }
    IEnumerable<T> RotateRight<T>(IEnumerable<T> list, int places)
    {
        return RotateLeft(list, list.Count() - places);
    }
