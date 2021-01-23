    namespace TrendsTwitterati
    {
         public partial class Default : System.Web.UI.Page
         {
              protected void Page_Load(object sender, EventArgs e)
              {
                   List<TweetEntity> tweetEntity = tt.GetTweetEntity(1, "").DistinctBy(e => e.EntityPicURL);
              }
         }
    }
