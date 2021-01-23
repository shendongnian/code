    > public int CheckDateBetween2Dates(DateTime Date)
    >         {
    >             try
    >             {
    >                 if (Date.Ticks >StartingDate.Ticks && Date.Ticks < EndDate.Ticks)
    >                 {
    >                     //..The Date is between the 2 dates return 1;
    >                 }
    >                 else
    >                 {
    >                     //..The Date is not between them return 0;
    >                 }
    >             }
    >             catch
    >             {
    >                 return -1;
    >             }
    > 
    >         }
