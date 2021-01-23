      public static class Extensions
        {
            public static IEnumerable<T> TakeOrDefault<T>(this IEnumerable<T> list, int totalElements)
            {
                List<T> finalList = list.ToList();
    
                if (list.Count() < totalElements)
                {
                    for (int i = list.Count(); i < totalElements; i++)
                    {
                        finalList.Add(Activator.CreateInstance<T>());
                    }
                }
    
                return finalList;
            }
        }
