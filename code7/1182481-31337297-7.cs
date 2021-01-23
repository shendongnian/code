            var listType = dict1[entry.Key].GetType();
            var secondListType = dict2[entry.Key].GetType();
            if (listType.IsGenericType && secondListType.IsGenericType)
            {
                //if you only have List<T> in there, you can pull the first one
                var genericType = listType.GetGenericArguments()[0];
                var secondGenericType = secondListType.GetGenericArguments()[0];
                if (genericType.IsEnum && genericType == secondGenericType && AreEqual((Ilist)dict1[entry.Key],(Ilist)dict2[entry.Key]))
                {                    
                    // List elements matches...
                }
            }
        public bool AreEqual(IList first, IList second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            for (var elementCounter = 0; elementCounter < first.Count; elementCounter++)
            {
                if (!first[elementCounter].Equals(second[elementCounter]))
                {
                    return false;
                }
            }
            return true;
        } 
