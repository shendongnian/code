     public static List<Staff_Time_TBLs> GetIndexed(string staffNo){
       var stuff  =    sql.Staff_Time_TBLs.Where(item =>                     
                     item.Section_Data == SelectedOption &&
                     item.Staff_No == staffNo;
       return stuff.ToList();
     }
  
     //to use it...
     initialQuery.ForEach(p=>{ 
         var indexvalue = GetIndexed(p)
     });
