    Task.Run(() => Process(smth));
     ...
     public void Process(bool smth)
     {
       try
       {
         if (smth) methodWhichAddelementTomyList();
         else otherThing();
       }
       finally
       {_executing = false;}
     }
