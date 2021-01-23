    public bool IsTwoInductions()
    {
       List<Induction> inductionList = GetInduction();
       bool isHaving90 = false;
       foreach (var items in inductionList)
       {
         introTime = items.TotalTime;
         if(introTime == 90)
         {
            isHaving90 = true;
            break;
         }
       }
       return isHaving90;
    }
