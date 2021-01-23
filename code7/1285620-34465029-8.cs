    public class DbBroker //: Home <-- circular reference
    {
        AuctionService auctionService = new AuctionService();
    
        public void executeQuery()
        {
            auctionService.getAll();
        }
    
        public void getArr()
        {
            string[] lista = auctionService.ListaAukcija.ConvertAll(obj => obj.ToString()).ToArray();
    
            ListBox1.Text = string.Join("\n", lista);
        }
    }
