    public partial class TestingForm2 : Form
    {
        private DataTable testDataTable;
        // Must Declare here so the value is stored in heap memory
        // so other functions can access and use the value
        private DataGridView testDataGridView;
        public TestingForm2()
        {
            InitializeComponent();
            buildDataTable();
            buildDataGridView();
            buildRadioButtons();
        }
        private void buildRadioButtons()
        {
            int numOfRadioButtons = testDataTable.Rows.Count;
            for(int i = 0; i < numOfRadioButtons; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Name = testDataTable.Rows[i].Field<string>("Name") + "RadioButton";
                rb.Text = testDataTable.Rows[i].Field<string>("Name");
                rb.Tag = testDataTable.Rows[i].Field<string>("Number");
                if(i == 0)
                {
                    rb.Checked = true;
                }
                rb.Location = new Point(5, 20 * (i + 1));
                rb.CheckedChanged += rb_CheckedChanged;
                panel1.Controls.Add(rb);
            }
        }
        private void buildDataGridView()
        {
            // Get number of rows in testDataTable
            int numOfRows = testDataTable.Rows.Count;
            // Build the empty DGV
            // If I were to declare the DGV here the value given would have
            // been stored in the memory stack and could only be accessed by
            // this function.  This is where I went wrong and made a silly mistake
            testDataGridView = new DataGridView();
            testDataGridView.Columns.Add("Name", "");
            testDataGridView.Columns.Add("Number", "");
            testDataGridView.Rows.Add(numOfRows);
            testDataGridView.Location = new Point(150, 20);
            testDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            testDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            testDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            testDataGridView.AllowUserToAddRows = false;
            testDataGridView.AllowUserToDeleteRows = false;
            testDataGridView.MultiSelect = false;
            testDataGridView.ColumnHeadersVisible = false;
            testDataGridView.RowHeadersVisible = false;
            panel1.Controls.Add(testDataGridView);
        }
        private void buildDataTable()
        {
            testDataTable = new DataTable();
            // Add the Columns
            testDataTable.Columns.Add("Name");
            testDataTable.Columns.Add("Number");
            // Create and add the rows
            for (int i = 0; i < 3; i++)
            {
                // Create the new row
                DataRow dr;
                object[] rowItems = new object[testDataTable.Columns.Count];
                if (i == 0)
                {
                    rowItems[0] = "Bob";
                    rowItems[1] = "1";
                }
                else if (i == 1)
                {
                    rowItems[0] = "John";
                    rowItems[1] = "2";
                }
                else
                {
                    rowItems[0] = "George";
                    rowItems[1] = "3";
                }
                // Add the row
                dr = testDataTable.NewRow();
                dr.ItemArray = rowItems;
                testDataTable.Rows.Add(dr);
            }
        }
        private void TestingForm2_Load(object sender, EventArgs e)
        {
            textBox1.Text = testDataGridView.Rows.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = testDataGridView.Rows.Count.ToString();
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            int index = int.Parse(rb.Tag.ToString()) - 1;
            if (rb.Checked)
            {
                testDataGridView.Rows[index].Selected = true;
            }
            
        }
    }
