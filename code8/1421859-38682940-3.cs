       Public Class MyCard:PictureBox
        {
          public CardType CardType {set;get;}
          public int GamePoint {get{ return (int)this.CardType;  }}
          public MyCard(CardType _cardType)
          {
           CardType = _cardType;
            }
        }
        enum CardType
        { Ace=1,
        King=2,
        ...
        }
