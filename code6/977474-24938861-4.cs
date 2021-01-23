    public abstract class CardContainer
    {
        public int Id { get; set; }
        public ICollection<Card> Cards { get; set; }
    
        protected CardContainer()
        {
            Cards = new List<Card>();
        }
    }
    
    public class Chassis : CardContainer
    {             
    }
    
    public class Card : CardContainer
    {
        public CardContainer Container { get; set; }
        public int ContainerId { get; set; }
    }    
