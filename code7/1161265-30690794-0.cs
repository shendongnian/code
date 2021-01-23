      public int Score()
    {
        int score = 0;
        int amountOfAces = 0;
        foreach (Card c in hand)
        {
            switch (c.Value)
            {
                    // Count all face cards as 10
                case 'A':
                    amountOfAces++;// increment aces by 1
                    score += 11;
                    break;
                case 'T':
                case 'J':
                case 'K':
                case 'Q':
                    score += 10;
                    break;
                default:
                    score += (c.Value - '0');
                    break;
            }
          // Then adjust score if needed
         if(amountOfAces>1){
            //since we know how many were found.
            score = score-amountOfAces*11;
            score = score+amountOfAces;
            }
           
        }
        return score;
    }
