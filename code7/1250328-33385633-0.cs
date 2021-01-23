                List<int> someObject = new List<int>();
                Type currentType = someObject.GetType();
    
                if (currentType.IsGenericType)
                {
                    if (currentType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // Do something
                    }
                    else if (currentType.GetGenericTypeDefinition() == typeof(HashSet<>))
                    {
                        // Do something else
                    }
                }
