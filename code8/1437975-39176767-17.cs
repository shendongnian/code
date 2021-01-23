    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TheScraper scraper = new TheScraper();
            List<Listing> listings = new List<Listing>();
            // quick hack to do a loop 5 times, to get all 5 pages. if this is being run frequently you'd want to automatically identify how many pages or start at page one and find / use link to next page.
            for (int i = 0; i < 5; i++)
            {
                listings = listings.Union(scraper.DoTheScrape(i)).ToList();
            }            
            string xmlListings = scraper.SerializeTheListings(listings);
        }
    }
