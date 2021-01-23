    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Web.UI.HtmlControls.HtmlButton btn = new System.Web.UI.HtmlControls.HtmlButton();
            btn.ID = "myID";
            btn.Attributes["class"] = "mdl-button mdl-js-button mdl-button--fab mdl-button--colored";
            btn.ServerClick += new EventHandler(someFunc);
            btn.InnerHtml = "<i class=\"material-icons\">add</i>";
            
            // you can add your button to some other parent control or to form
            myCustomPanel.Controls.Add(btn);
        }
    }
    protected void someFunc(object sender, EventArgs e)
    {
        // your code
    }
