    int[] rollDice(int diceCount)
       {
           if(diceCount <= 0)
               throw new ArgumentException("Dice must be at least 1");
    
            int[] result = new int[diceCount];
            for(int i=0;i<diceCount;i++)
            {
                if(i < 3)
                {
                    //Roll die...
                    result[i] = 1;//Roll the die (not 1, use a random)
                }
                else
                {
                    result[i] = 0;
                }
          }
    
          return result;
        }
