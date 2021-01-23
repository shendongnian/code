    public partial class DynamicUserControls : System.Web.UI.Page
    {
        protected UserControl userCtrl;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Page.IsPostBack)
                CreateUserControl();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CreateUserControl();
            else
            {
                lbl.Text = "The following values were selected: " + string.Join(", ", ((IGetSelectedValues)userCtrl).SelectedValues);
            }
        }
        private void CreateUserControl()
        {
            if (Request["UserCtrl"] == "A")
            {
                userCtrl = (UserControl) LoadControl("~/MyUserControlA.ascx");
                userCtrl.ID = "myUserCtrl";
                wizardPanel.Controls.Add(userCtrl);
            }
            else if (Request["UserCtrl"] == "B")
            {
                userCtrl = (UserControl)LoadControl("~/MyUserControlB.ascx");
                userCtrl.ID = "myUserCtrl";
                wizardPanel.Controls.Add(userCtrl);
            }
        }
    }
