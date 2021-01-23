            var listType = dict1[entry.Key].GetType();
            var secondListType = dict2[entry.Key].GetType();
            if (listType.IsGenericType && secondListType.IsGenericType)
            {
                //if you only have List<T> in there, you can pull the first one
                var genericType = listType.GetGenericArguments()[0];
                var secondGenericType = secondListType.GetGenericArguments()[0];
                if (genericType.IsEnum && genericType == secondGenericType && dict1[entry.Key].SequenceEqual(dict2[entry.Key]))
                {                    
                    // List elements matches...
                }
            } 
