    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private DataGridView x = new DataGridView();
            public Form1()
            {
                InitializeComponent();
                Controls.Add(x);
                x.Columns.Add("name", "header");
                for (int i = 0; i < 100; i++)
                {
                    x.Rows.Add(i.ToString());
                }
                VScrollBar sc = new VScrollBar();
                sc.Dock = DockStyle.Right;
                sc.Minimum = 0;
                sc.Maximum = x.Rows.Count;
                sc.Scroll += sc_Scroll;
                x.Controls.Add(sc);
            }
            private void sc_Scroll(object sender, ScrollEventArgs e)
            {
                x.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }
    }
