     List<Product> list1;
     List<Advert> list2 ;
     //Full list1 && list 2
     int counterForList2 = 0;
     foreach (string value in list1)
     {
         Console.WriteLine(value);
         if (list1.Count() % 5 == 0)
         {
             if (counterForList2 == list2.Count)
                 counterForList2 = 0;
             Console.WriteLine(list2[counterForList2]);
             counterForList2++;
         }
     }
