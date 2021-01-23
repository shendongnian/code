    public class MyFile
    {
        public int fileid { get; set; }
        public string filename { get; set; }
    }
    public partial class PopupInGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var f1 = new MyFile { fileid = 1, filename = "File 1" };
                var f2 = new MyFile { fileid = 2, filename = "File 2" };
                var files = new List<MyFile> { f1, f2 };
                FileTableView.DataSource = files;
                FileTableView.DataBind();
            }
        }
        protected void File_Command(object sender, CommandEventArgs e)
        {
            string command = e.CommandName;
            string fileId = Session["fileid"] as string; 
            switch (command)
            {
                case "ShowPopup":
                    Session["fileid"] = e.CommandArgument;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "showPopup();", true);
                    break;
                case "Delete":
                    //Your delete logic...
                    break;
                case "Download":
                    //Your download logic...
                    break;
            }
        }
    }
