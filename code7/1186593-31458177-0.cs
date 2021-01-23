    public partial class Form1: System.Web.UI.Page
    {
        protected string url { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            getdata(); //your method which assigns a value to url
            DataBind();
        }
    }
