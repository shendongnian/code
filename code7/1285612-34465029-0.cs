    //the model
    public class Auction {
        public string Productname { get; set; }
        public string Lastbidder { get; set; }
        public int Bidvalue { get; set; }
    }
    
    //the service (or can replace this with a repository)
    public class AuctionService {
        private List<Auction> listaAukcija = new List<Auction>();
    
        public List<Auction> ListaAukcija
        {
            get { return listaAukcija; }
            set { listaAukcija = value; }
        }
        
        public void getAll()
        {
            //get the data...
        }
    }
