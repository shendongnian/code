    var rows = Sum("5#9#6#4#6#8#0#7#1#5");
    var total = rows.Sum();
    private static IEnumerable<int> Sum(string inp)
    {
        int i = 0, s = 0, z = 1;
        foreach (var v in inp.Split('#').Select(int.Parse))
        {
            s = Math.Max(s, v);
            if (++i == z)
            {
                z++;
                yield return s;
                s = i = 0;
            }
        }
    }
