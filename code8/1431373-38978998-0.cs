     //....
     var j = 0;
     for (int i = 0; i < Alist.Count; i++)
     {
           Result += Alist[i];
           if (j < Blist.Count)
                Result += Blist[j++];
      }
      while (j < Blist.Count) //in case B length> A length
         Result += Blist[j++];
      Console.WriteLine(Result);
      Console.ReadLine();
      //....
