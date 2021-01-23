     int size = 5;
     List<string[]> ArrList = new List<string[]>();
     for (var i = 0; i < myList.Count; i+=size)
     { 
         ArrList.Add(myList.Skip(i).Take(size));   
     }
