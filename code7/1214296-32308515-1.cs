        char get_REVISIONMARK = 'A';
        var res = arrange_REVISIONSERIES.Select(s => new { Rev = s[s.Length - 1], Value = int.Parse(s.Substring(0, s.Length - 1)), Org = s })
            .Where(d => d.Rev == get_REVISIONMARK).OrderBy(d => d.Value)
            .Select((val, ind) => new { Index = ind, Org = val.Org, Value = val.Value }).GroupBy(a => a.Value - a.Index)
            .Select(gr=>gr.ToList()).OrderBy(l=>l.Count > 2 ? 0 : 1 ).Aggregate(new List<string>(), (list, sublist) =>
            {
                if (sublist.Count > 2)
                    list.Add(sublist[0].Org + " - " + sublist[sublist.Count - 1].Org);
                else
                    list.AddRange(sublist.Select(a => a.Org));
                return list;
            });
