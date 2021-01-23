    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApp.DynamicControls2
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ControlsCount = 0;
                }
                else
                {
                    for (int i = 0, j = ControlsCount; i < j; i++)
                    {
                        CreateControl();
                    }
                }
            }
    
            protected override void LoadViewState(object savedState)
            {
                base.LoadViewState(savedState);
            }
    
            int ControlsCount
            {
                get
                {
                    if (ViewState["ControlsCount"] == null)
                    {
                        int count = 0;
                        ViewState["ControlsCount"] = count;
                        return count;
                    }
                    return (int)ViewState["ControlsCount"];
                }
                set
                {
                    ViewState["ControlsCount"] = value;
                }
            }
    
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                CreateControl(true);
            }
    
            protected void btnCount_Click(object sender, EventArgs e)
            {
    
            }
    
            void CreateControl(bool UpdateCount = false)
            {
                TextBox tbx = new TextBox();
                Button btn = new Button() { Text = "Get Time" };
                btn.Click += btn_Click;
                Literal br = new Literal() { Text = "<br/>" };
                var ctls = phContainer.Controls;
                ctls.Add(tbx);
                ctls.Add(btn);
                ctls.Add(br);
                if (UpdateCount) ControlsCount++;
            }
    
            void btn_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                Control parent = btn.Parent;
                int index = parent.Controls.IndexOf(btn);
                TextBox tbx = parent.Controls[index - 1] as TextBox;
                tbx.Text = DateTime.Now.ToLongTimeString();
            }
        }
    }
