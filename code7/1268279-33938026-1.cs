    private static List<Item> callingprogram2(List<Item> paramss )
    {
                    bool containsvalue=true;
                                      
                    foreach(var item in paramss)
                    {
                         if(item.c==0)
                        {
                             containsvalue=false;
                             break;
                        }
                    }
                    if(containsvalue==true)
                        return paramss;
                    else 
                        return null;
    }
