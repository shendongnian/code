        var genericList = list.Cast<object>();
        for(int i = 0; i < genericList.Count(); ++i)
        {
           var row = genericList.ElementAt(i);
           /* .... */
        }
