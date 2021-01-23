    using FeedPath;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FeedPath myObject = new FeedPath();
            myobject.ParseFeed() //Fill the () of your .ParseFeed() method with your parameters.    
        }
    }
