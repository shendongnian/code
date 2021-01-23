       List<T> AddToCopy(this List<T> list, T newItem)
       {
           var newList = list;
           newList.Add(newItem); // changed existing list...
           return newList;
       }
