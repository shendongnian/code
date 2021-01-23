    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TheScraper scraper = new TheScraper();
            List<Listing> listings = scraper.DoTheScrape();
            string xmlListings = scraper.SerializeTheListings(listings);
    
