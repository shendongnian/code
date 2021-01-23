    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TheScraper scraper = new TheScraper();
            List<Listing> listings = new List<Listing>();
            // do a loop 4 times, to get all 4 pages.
            for (int i = 0; i < 5; i++)
            {
                listings = listings.Union(scraper.DoTheScrape(i)).ToList();
            }            
            string xmlListings = scraper.SerializeTheListings(listings);
        }
    }
