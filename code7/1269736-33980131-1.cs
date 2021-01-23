     public class Card
     {
        public suits suit { get; set; }
        public cardValues cardValue { get; set; }
    
        //Complex object don't automatically know how to
        //to display it's ToString() which is what Console.Writeline()
        //calls
        public override string ToString()
        {
            return string.Format("{0} of {1}", cardValue, suit);
        }
     }
