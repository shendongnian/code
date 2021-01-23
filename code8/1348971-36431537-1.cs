    public static IEnumerable<int> GetItemsList2(HashSet<DateTime> requiredTimestamps)
        {
            List<int> toReturn = new List<int>();
            foreach (var dateTime in _containedObjects)
            {
                int found;
                if (requiredTimestamps.Contains(dateTime.Key))
                {
                    toReturn.Add(dateTime.Value);
                }
            }
            return toReturn;
        }
