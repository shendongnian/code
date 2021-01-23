    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TheScraper scraper = new TheScraper();
            List<Listing> listings = new List<Listing>();
            // do a loop 4 times, to get all 4 pages.
            for (int i = 0; i < 4; i++)
            {
                listings = scraper.DoTheScrape(i);
            }            
            string xmlListings = scraper.SerializeTheListings(listings);
        }
    }
