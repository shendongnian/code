    private static string ConcatAll<T>(T nestedList) where T : IList
    {
        dynamic templist = nestedList;
        while (!(templist[0] is char?))
        {
            List<dynamic> inner = new List<dynamic>(templist).SelectMany<dynamic, dynamic>(x =>
            {
                var s = x as string;
                if (s != null)
                {
                    return s.Cast<dynamic>();
                }
                return x;
            }).ToList();
            templist = inner;
        }
        return new string(((List<object>) templist).Select(x => (char) x).ToArray());
    }
