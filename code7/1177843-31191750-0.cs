      foreach (var s in list3)
       {
          var index = list1.FindIndex(list3.Contains);
          list2.RemoveAt(index);
          list1.RemoveAt(index);
       }
