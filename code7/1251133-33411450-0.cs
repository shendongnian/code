    public void IsTwoInductions()
    {
       List<Induction> inductionList = GetInduction();
       int? introTime = 0;
       foreach (var items in inductionList)
       {
         introTime = items.TotalTime;
    
         if(introTime == 90)
         {
            Console.Write("true ");
         }
         else
         {
            Console.Write("false ");
         }
       }
    }
