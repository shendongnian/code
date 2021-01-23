    public static class Extensions
    {
        public static int IndexOf(this System.Collections.Specialized.OrderedDictionary od, object key)
        {
            for (int index = 0; index < od.Count; index++)
            {
                if (od.Keys.OfType<object>().ToList()[index] == key)
                    return index;
            }
            return -1;
        }
    }
