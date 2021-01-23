    List<string> C = new List<string>();
    // nA is the length of list A & nB is the length of list B 
    for (int x = 0; x < nA; x++)
    {
         boolean found = false;
         for (int y = 0; y < nB; y++)
         {
             if (listA[x] == listB[y])
             {
                listC.Add(lista[x]);
                found = true;
                break;
             }
         }
         if (!found)
            listC.Add(null);
    }
