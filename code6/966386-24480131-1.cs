    foreach(var item in myList)
    {
       if(item.Id > 0)
          context.Entry(item).State = EntityState.Modified;          
       else
          context.Table.Add(item);
    }
