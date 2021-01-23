        private List<CheckBox> checkboxes = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent();
            FillCheckboxes();
        }
        private void CheckAll()
        {
            foreach (var chk in checkboxes)
            {
                chk.Checked = true;
            }            
        }
        private void FillCheckboxes()
        {
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    checkboxes.Add(c as CheckBox);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
        }
