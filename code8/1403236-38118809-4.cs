    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            path = "test.xml";
            dataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
            buttonLoad = new Button { Parent = this, Top = 170, Text = "Load" };
            buttonSave = new Button { Parent = this, Top = 200, Text = "Save" };
            buttonLoad.Click += ButtonLoad_Click;
            buttonSave.Click += ButtonSave_Click;
        }
        DataGridView dataGridView;
        Button buttonSave;
        Button buttonLoad;
        string path;
        DataTable dataTable;
        DataSet dataSet;
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet("Root");
            if (File.Exists(path))
            {
                dataSet.ReadXml(path, XmlReadMode.InferSchema);
                dataTable = dataSet.Tables[0];
            }
            else
            {
                dataTable = new DataTable("dt");
                dataTable.Columns.Add("Name").ColumnMapping = MappingType.Attribute;
                dataTable.Columns.Add("Value").ColumnMapping = MappingType.Attribute;
                dataTable.Rows.Add("name1", "value1");
                dataTable.Rows.Add("name2", "value2");
                dataSet.Tables.Add(dataTable);
            }
            dataGridView.DataSource = dataTable;
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataSet != null)
                dataSet.WriteXml(path);
        }
    }
