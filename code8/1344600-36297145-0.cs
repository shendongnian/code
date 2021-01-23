    public class Card{
        public Picturebox pic;
        public int Id; 
    }
    
    List<Card> Cards= new List<Card>();
    
      public void addInt(int numberOfCards)
        {
            for(int i = 1; i <= numberOfCards; i++)
            {
                Cards.Add(new Card(){
                      pictureBoxes= pb,
                      id = i
                });
            }
        }
