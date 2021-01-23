    public static List<List<T>> GroupItems<T>(this List<T> items, int totalGroups)
        {
            if (items == null || totalGroups == 0) return null;
            var ret = new List<List<T>>();
            var avg = items.Count / totalGroups; //int  rounds towards 0
            var extras = items.Count - (avg * totalGroups);
            for (var i = 0; i < totalGroups; ++i)
                ret.Add(items.Skip((avg * i) + (i < extras ? i : extras)).Take(avg + (i >= extras ? 0 : 1)).ToList());
            return ret;
        }
