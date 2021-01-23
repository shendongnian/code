    public partial class DetailsViewWithConditionalColumns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                this.BindData();
        }
        private void BindData()
        {
            var ftp1 = new FTPDetails { Type = "FTP", IP = "1.1.1.1", Port = "21" };
            var ftp2 = new FTPDetails { Type = "SFTP", IP = "2.2.2.2", Port = "22" };
            detailsView.DataSource = new List<FTPDetails> { ftp1, ftp2 };
            detailsView.DataBind();
        }
        protected void detailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            detailsView.PageIndex = e.NewPageIndex;
            this.BindData();
        }
    }
    public class FTPDetails
    {
        public string Type { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
    }
