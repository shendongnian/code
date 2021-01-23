    public void Tester()
    {
        int level = 1;
        while (level < 6)
        {
            bool direction;
             switch (level)
             {
                case 1:
                    direction = DoLevel1Stuff();
                    level += direction ? 1 : -1;
                    break;
                case 2:
                    direction = DoLevel2Stuff();
                    level += direction ? 1 : -1;
                    break;
                
                //etc
              }
         }
         Console.WriteLine("You win!");
     }
     public bool DoLevel1Stuff()
     {
         bool didTheyPass;
         while (condition)
         {
             //stuff
         }
          return didTheyPass;
      }
       public bool DoLevel2Stuff()
       {
           
       }
