    public partial class MyPage: System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            Global.BackgroundCaller.QueueBackgroundRequest("http://www.example.com/service.aspx");
        }
    }
