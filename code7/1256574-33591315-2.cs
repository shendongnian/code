    char[] delimiter1 = { '[', ']' };
    char[] delimiter2 = { ';' };
    char[] delimiter3 = { ' ' };
    string[][] words = text.Split(delimiter1)[1]
                           .Split(delimiter2, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => x.Split(delimiter3, StringSplitOptions.RemoveEmptyEntries))
                           .ToArray();
