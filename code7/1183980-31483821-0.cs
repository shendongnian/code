    public partial class Form1 : Form
    {
        DataTable dtSrc;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtSrc = new DataTable();
            DataColumn dc = dtSrc.Columns.Add("Text");
            dtSrc.Rows.Add("ComboBox Text");
            dtSrc.Rows.Add("Long ComboBox Text");
            dtSrc.Rows.Add("Longer ComboBox Text");
            dtSrc.Rows.Add("Really Longer ComboBox Text");
            dtSrc.Rows.Add("Exceptionally Longer ComboBox Text");
            dtSrc.Rows.Add("A ghastly amount of textual information that is to be used for the dropdown as ComboBox Text");
            // ComboBox in Grid
            GridViewComboBoxColumn cbCol = new GridViewComboBoxColumn();
            cbCol.Name = "cbCol";
            cbCol.HeaderText = "CB";
            cbCol.DataSource = dtSrc;
            cbCol.DisplayMember = "Text";
            cbCol.Width = 150;
            this.radGridView1.Columns.Add(cbCol);
            // MultiComboBox in Grid
            GridViewMultiComboBoxColumn mcbCol = new GridViewMultiComboBoxColumn();
            mcbCol.Name = "mcbCol";
            mcbCol.HeaderText = "MCB";
            mcbCol.DataSource = dtSrc;
            mcbCol.DisplayMember = "Text";
            mcbCol.Width = 150;
            this.radGridView1.Columns.Add(mcbCol);
            // TextBox in Grid
            GridViewTextBoxColumn txtCol = new GridViewTextBoxColumn();
            txtCol.Name = "txtCol";
            txtCol.HeaderText = "TXT";
            txtCol.Width = 400;
            this.radGridView1.Columns.Add(txtCol);
        }
        private void radGridView1_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Column == radGridView1.Columns["cbCol"])
            {
                RadDropDownListEditor cboEditor = this.radGridView1.ActiveEditor as RadDropDownListEditor;
                cboEditor.EditorElement.StretchVertically = false;
                cboEditor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
                cboEditor.DropDownSizingMode = SizingMode.UpDownAndRightBottom;
            }
            if (e.Column == radGridView1.Columns["mcbCol"])
            {
                RadMultiColumnComboBoxElement mcboEditor = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                mcboEditor.EditorControl.Columns["Text"].MinWidth = 300;
                mcboEditor.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                mcboEditor.EditorControl.ShowRowHeaderColumn = false;
                mcboEditor.DropDownMinSize = new Size(350, 150);
                mcboEditor.DropDownSizingMode = SizingMode.UpDownAndRightBottom;
            }
        }
    }
