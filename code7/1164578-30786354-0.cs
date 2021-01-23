GetDlgCtrlID from user32.dll will provide the control ID given the window handle (ie, Control.Handle). Very simple form to demonstrate:
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            [DllImport("user32.dll")]
            static extern int GetDlgCtrlID(IntPtr hwnd);
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                MessageBox.Show("Control ID: " + GetDlgCtrlID(textBox1.Handle));
            }
        }
    }
