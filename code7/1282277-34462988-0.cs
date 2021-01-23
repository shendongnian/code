     public void Update(Guid id, T record)
            {
                using (var context = new FortisDataStoreContext(_client, _user))
                {
                    var set = context.Set<T>().AsQueryable();
    
                    foreach (var x in GetNavigationProperties(context, record))
                    {
                        foreach (var xx in x.PropertyType.GetGenericArguments())
                        {
                            set = set.Include(x.Name);
                        }
                    }
    
                    var entry = set.FirstOrDefault(x => x.Id == id && x.IsClosed == false);
                    context.Entry(entry).CurrentValues.SetValues(record);
    
                    foreach (var x in GetNavigationProperties(context, record))
                    {
                        if(x.PropertyType.GetGenericArguments().Count() > 0)
                        {
                            var genericType = x.PropertyType.GenericTypeArguments[0];
                            var newValues = (IList)x.GetValue(record, null) ?? new object[0];
                            var genericList = CreateList(genericType);
                            foreach (var item in newValues)
                            {
                                var ident = item.GetType().GetProperty("Id").GetValue(item, null);
                                var obj = context.Set(genericType).Find(ident);
                                genericList.Add(obj);
                            }
                            context.Entry(entry).Collection(x.Name).CurrentValue = genericList;
                        }
                    }
    
                    context.SaveChanges();
                }
            }
