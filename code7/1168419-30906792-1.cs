    while (reader.Read() && !flag)
    {
         ....
         for (int i = 1; i <= Minutesdifference; i++)
         {
               if ((Classroom == ClassroomNo && dt == dt2 && StartTime == NewTime) || (Classroom == ClassroomNo && dt == dt2 && StartTime == ST))
                                {
                                    flag = 1;
                                    
                                    break;
                                }
                               else
                               {flag=0;}
                            ...
         }
    }
