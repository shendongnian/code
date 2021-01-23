    public partial class TabPageForm : Form
    {
        private List<string> tabNames;
        public TabPageForm()
        {
            InitializeComponent();
            tabNames = new List<string>();
            tabNames.Add("NewTab");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool first = true;
            foreach (string tabName in tabNames)
            {
                TabPage tabPage = CreateTabPage(tabName);
                methodTabPage.Controls.Add(tabPage);
                if (first)
                {
                    methodTabPage.Select();
                    first = false;
                }
            }
        }
        private TabPage CreateTabPage(String name)
        {
            TabPage tabPage = new TabPage(name);
            tabPage.Enter += new EventHandler(MethodTab_Entered);
            return tabPage;
        }
        private void MethodTab_Entered(object sender, EventArgs e)
        {
            DoSomething();
        }
        private void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
