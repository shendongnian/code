    public class CustomControl : UserControl
    {
        private DataGridViewImageColumn EditStatusIcons;
        public DataGridView DGV;
        private bool hasIcons = true;
        public bool HasIcons
        {
            get { return this.hasIcons; }
            set
            {
                if (this.DGV.Columns["EditStatusIcons"] == null) return;
                this.dataGridView1.Columns["EditStatusIcons"].Visible = value;
                this.hasIcons = value;
            }
        }
        public CustomDataGridView()
        {
            this.EditStatusIcons = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditStatusIcons.HeaderText = "";
            this.EditStatusIcons.Name = "EditStatusIcons";
            this.DGV= new DataGridView();
            this.DGV.Dock = DockStyle.Fill;
            this.DGV.Columns.Add(this.EditStatusIcons);
            this.Controls.Add(this.DGV);
        }
    }
