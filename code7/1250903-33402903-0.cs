    public partial class Feed_Feed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void TweetButton_Click(object sender, EventArgs e)
        {
           if(TweetBox.Text.Length <= 140)
           {
             // Save data in the database.
           }
        }
    
    }
