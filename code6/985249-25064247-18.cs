    static void CheckForEquality(string path,
                                 object a, object b, 
                                 List<string> differences)
    {
        if (a.Equals(b))
            return;
        var comparableA = a as IComparable;
        if (comparableA != null && comparableA.CompareTo(b) != 0)
            differences.Add(path);
        if (Object.ReferenceEquals(b, null))
        {
            differences.Add(path);
            return; // This is mandatory: nothing else to compare
        }
        if (b.Equals(a))
            return true;
        var type = a.GetType();
        if (type != b.GetType())
        {
            differences.Add(path);
            return; // This is mandatory: we can't go on comparing different types
        }
        var listA = a as System.Collections.ICollection;
        if (listA != null)
        {
            var listB = b as System.Collections.ICollection;
            if (listA.Count == listB.Count)
            {
                var aEnumerator = listA.GetEnumerator();
                var bEnumerator = listB.GetEnumerator();
    
                int i = 0;
                while (aEnumerator.MoveNext() && bEnumerator.MoveNext())
                {
                	CheckForEquality(
                        String.Format("{0}[{1}]", path, i++),
                        aEnumerator.Current, bEnumerator.Current, differences);
                }
            }
            else
            {
                differences.Add(path);
            }
        }
        var properties = type.GetProperties().Where(x => x.GetMethod != null);
        foreach (var property in properties)
        {
			CheckForEquality(
                String.Format("{0}.{1}", path, property.Name),
                property.GetValue(a), property.GetValue(b), differences);
        }
    }
