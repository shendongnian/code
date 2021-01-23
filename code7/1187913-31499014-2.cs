    public Form1()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            TogglePanels();
        }
        public void TogglePanels()
        {
            List<Panel> allPanelsInForm = new List<Panel>();
            foreach (var control in Controls)
            {
                if (control is Panel)
                    allPanelsInForm.Add(control as Panel);
            }
            Panel visiblePanel = allPanelsInForm.Where(o => o.Visible).FirstOrDefault();
            int nextPanelId = Convert.ToInt32(visiblePanel.Tag) + 1;
            bool nextPanelExists = allPanelsInForm.Exists(o => Convert.ToInt32(o.Tag) == nextPanelId);
            nextPanelId = nextPanelExists ? nextPanelId : 1;
            foreach (Panel panel in allPanelsInForm)
            {
                panel.Visible = Convert.ToInt32(panel.Tag) == nextPanelId ? true : false;
            }
        }
 
