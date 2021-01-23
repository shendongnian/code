    using System;
    using System.Windows.Forms;
    using System.Drawing;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                var c = new DataGridViewTextBoxCell();
                c.ReadOnly = false;
                this.dataGridView1.Columns.Add(new DataGridViewColumn(c));
                this.dataGridView1.Rows.Add(5);
                this.dataGridView1.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
            }
            private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
            {
                var currentSymbol = "test";
                if (e.KeyCode == Keys.ControlKey)
                {
                    foreach (DataGridViewCell c in dataGridView1.SelectedCells)
                    {
                        c.ReadOnly = false;
                        c.Style.BackColor = Color.White;
                        c.Style.ForeColor = Color.Black;
                        c.ValueType = currentSymbol.GetType();
                        c.Value = currentSymbol;
                        dataGridView1.BeginEdit(true);
                        dataGridView1.EndEdit();
                    }
                }
            }
        }
    }
