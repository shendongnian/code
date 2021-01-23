            var seenElements = new HashSet<T>();
            var repeatedElements = new HashSet<T>();
            foreach (var list in source)
            {
                foreach (var element in list.Distinct())
                {
                    if (seenElements.Contains(element))
                    {
                        repeatedElements.Add(element);
                    }
                    else
                    {
                        seenElements.Add(element);
                    }
                }
            }
            return repeatedElements;
