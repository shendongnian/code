        char get_REVISIONMARK = 'A';
        var res = arrange_REVISIONSERIES.Select(s => new { Rev = s[s.Length - 1], Value = int.Parse(s.Substring(0, s.Length - 1)) })
            .Where(d => d.Rev == get_REVISIONMARK).OrderBy(d => d.Value)
            .Select((val, ind) => new { Index = ind, Rev = val.Rev, Value = val.Value }).GroupBy(a => a.Value - a.Index)
            .Select(gr=>gr.ToList()).OrderBy(l=>l.Count > 2 ? 0 : 1 ).Aggregate(new List<string>(), (list, sublist) =>
            {                    
                Func<int, string> tostring = i => sublist[i].Value.ToString() + sublist[i].Rev;
                if (sublist.Count > 2) //only create range of subranges
                    list.Add(tostring(0) + " - " + tostring(sublist.Count - 1));
                else
                    list.AddRange(Enumerable.Range(0, sublist.Count).Select(tostring));
                return list;
            });
