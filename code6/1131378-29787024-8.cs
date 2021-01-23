            for (var i = 0; i < listA.Count; i++)
            {
                if (!exists(dataContext, listA[i], listB[i])) 
                {
                    LIST_OBJECTS listObject = new LIST_OBJECTS
                    {
                        LIST_KEY = 1,
                        LIST_ITEM_A = listA[i],
                        LIST_ITEM_B = listB[i]
                    };
                    dataContext.LIST_OBJECTS.Add(listObject);
                }
            }
            dataContext.SaveChanges();
