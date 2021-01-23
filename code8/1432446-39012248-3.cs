       List<ClassA> A = ...
       List<ClassB> B = ...
    
       var result A
         .Concat<BaseAB>(B)
         .OrderByDescending(item => item.Date);
    
       foreach (var item in result) {
         var itemA = item as A;
    
         if (itemA != null) {
           ... 
         }
         else {
           var itemB = item as B;  
           ...  
         } 
       }
