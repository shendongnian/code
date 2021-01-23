    public class MyVideo
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                gvShow.DataSource = new List<MyVideo> { new MyVideo { ID = 0, Name = "Initial..." } };
                gvShow.DataBind();
            }
        }
        [System.Web.Services.WebMethod]
        public static List<MyVideo> GetVideos(string videoid)
        {
            MyVideo v1 = new MyVideo { ID = 1, Name = "Video 1" };
            MyVideo v2 = new MyVideo { ID = 1, Name = "Video 2" };
            MyVideo v3 = new MyVideo { ID = 3, Name = "Video 3" };
            var videos = new List<MyVideo> { v1, v2, v3 };
            return videos.Where(v => v.ID == 1).ToList();//Hardcoding for simplicity
        }
    }
