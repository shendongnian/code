    listArray = new[] {list1, list2, list3, list4}; // you can add more as needed to this master array
    for (int i = 0; i < listArray.Count; i++)
    {
         if (listArray[i].Count > 1)
         {
             for (int i = 0; i < listArray.Count; i++)
             {
                 DoSomething(listArray[i]); 
             }
             break; // http://msdn.microsoft.com/en-us/library/adbctzc4.aspx
         }
    }
