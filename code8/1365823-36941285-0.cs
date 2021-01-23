    using System;
    using System.Data;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                //InitializeComponent();
                this.Width = 400;
                dtPersons = new DataTable();
                dtPersons.Columns.Add("Name", typeof(string));
                dtPersons.Columns.Add("Age", typeof(int));
                // Should be read from file
                dtPersons.LoadDataRow(new object[] { "John", 30 }, false);
                dtPersons.LoadDataRow(new object[] { "Smit", 35 }, false);
                dtPersons.LoadDataRow(new object[] { "Jack", 25 }, false);
                dtPersons.LoadDataRow(new object[] { "Brad", 20 }, false);
                dtPersons.LoadDataRow(new object[] { "Paul", 40 }, false);
                var dgv = new DataGridView { Parent = this, Dock = DockStyle.Top };
                dgv.DataSource = dtPersons;
                tbFilterName = new TextBox { Parent = this, Top = dgv.Bottom + 30, Width = 150 };
                nudFilterAge = new NumericUpDown { Parent = this, Top = tbFilterName.Top, Left = tbFilterName.Right + 50 };
                var btnFilterName = new Button { Parent = this, Top = dgv.Bottom + 60, Text = "Apply filter by Name", AutoSize = true };
                var btnBothFilters = new Button { Parent = this, Top = dgv.Bottom + 60, Text = "Apply both filters", AutoSize = true, Left = btnFilterName.Right + 20 };
                var btnFilterAge = new Button { Parent = this, Top = dgv.Bottom + 60, Text = "Apply filter by Age", AutoSize = true, Left = btnBothFilters.Right + 20 };
                btnFilterName.Click += BtnFilterName_Click;
                btnBothFilters.Click += BtnBothFilters_Click;
                btnFilterAge.Click += BtnFilterAge_Click;
            }
            DataTable dtPersons;
            TextBox tbFilterName;
            NumericUpDown nudFilterAge;
            private void BtnFilterAge_Click(object sender, EventArgs e)
            {
                string filter = $"Age > '{nudFilterAge.Value}'";
                dtPersons.DefaultView.RowFilter = filter;
            }
            private void BtnBothFilters_Click(object sender, EventArgs e)
            {
                string filter = $"Name = '{tbFilterName.Text}' or Age > '{nudFilterAge.Value}'";
                dtPersons.DefaultView.RowFilter = filter;
            }
            private void BtnFilterName_Click(object sender, EventArgs e)
            {
                string filter = $"Name = '{tbFilterName.Text}'";
                dtPersons.DefaultView.RowFilter = filter;
            }
        }
    }
