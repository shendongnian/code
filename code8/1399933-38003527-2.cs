    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class SampleForm : Form
        {
            DataGridView dataGridView1 = new DataGridView();
            public SampleForm()
            {
                this.dataGridView1.Dock = DockStyle.Fill;
                this.Controls.Add(this.dataGridView1);
                this.dataGridView1.Columns.Add("Column0", "Column Zero");
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    ValueType = typeof(decimal),
                    Name = "Column1",
                    HeaderText = "Column One"
                });
                this.dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Rows.Add("Value 1", 12345.67);
                this.dataGridView1.Rows.Add("Value 2", 987654.32);
            }
        }
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SampleForm());
            }
        }
    }
