                private static List<Item> CallIngprogram1()
                {
                    bool containsvalue=true;
                    List<Item> list = new List<Item>();
                    list.Add(new Item
                    {
                        a = 1,
                        b = 3
                        // c value is not assign so it contain the default value
                    });
                    
                    foreach(var item in list)
                    {
                         if(item.c==0)
                        {
                             containsvalue=false;
                             break;
                        }
                    }
                    if(containsvalue==true)
                        return list;
                    else 
                        return null;
                }
