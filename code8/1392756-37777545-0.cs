    using System;
    using System.Windows.Forms;
    namespace FormTest
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Form1 frm = new Form1();
                UserControl edt = new UserControl();
                edt.Name = "ItemEdit";
                frm.Controls.Add(edt);
                Application.Run(frm);
            }
        }
    }
    using System.Windows.Forms;
    namespace FormTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, System.EventArgs e)
            {
                Control[] tbxs = this.Controls.Find("ItemEdit", true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    MessageBox.Show("Found");
                }
            }
        }
    }
