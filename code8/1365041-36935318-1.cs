     for (int loopCounter = 0; loopCounter < signList.Count; loopCounter++)
     {
    if (userBD >= signList[loopCounter].startDate && userBD <=  signList[loopCounter].endDate)
      {
         Console.WriteLine(signList[loopCounter].signName);
         break;
      }              
    }
