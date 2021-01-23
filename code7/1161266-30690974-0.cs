    public int Score()
    {
        var score = 0;
        var aceCount = 0;
        foreach (Card c in hand)
        {
            switch (c.Value)
            {
                case 'A':
                    aceCount++;
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
        }
        if(aceCount == 0)
        {
            return score;
        }
        //Any ace other than the first will only be worth one point.
        //If there is only one ace, no score will be added here.
        score += (aceCount-1);
        //Now add the correct value for the last Ace.
        if(score < 11)
        {
            score += 11;
        }
        else
        {
            score++;
        }
        return score;
    } 
