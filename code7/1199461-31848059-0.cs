    enum Target { DOUBLES, WINNERS } // add as many as you want.
    public static List<string> GetTarget(Prize prize, Target lookingFor)
    {
    ....
    // define the query
        switch(lookingFor) // take care of each case in the enum.
        {
         case Target.DOUBLES:
           query = string.Concat(
                @"
                    SELECT Member.IBAN ",
                    "FROM Member, Summary ",
                    "WHERE Member.ID = Summary.DoubleID ",
                    "AND PrizeID = " + prize.ID
            );
            break;
          case Target.WINNERS:
            query = string.Concat(
                @"
                    SELECT Member.IBAN ",
                    "FROM Member, Summary ",
                    "WHERE Member.ID = Summary.WinnerID ",
                    "AND PrizeID = " + prize.ID
            );
            break;
           default: // in case you got a bad value
               //throw an exception
            break;
             
        }
    //Do stuff with the query.
    }
