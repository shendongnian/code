     var A = new List<String>();
     foreach(var item in serialize)
     {
         if(j==0)
         {
             A = item.Item2;
             j = 1;    
         }
         else
             A =  Cartesian(A, item.Item2);
      }
