    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            subject subject1;
            string DocPath = AppDomain.CurrentDomain.BaseDirectory + "Documents/";
            public Form1()
            {
                InitializeComponent();
                subject1 = new subject();
                materialRaisedButton1.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton2.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton3.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton4.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton5.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton6.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton7.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton8.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton9.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton10.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton11.Click += new EventHandler(materialRaisedButton_Click);
                materialRaisedButton12.Click += new EventHandler(materialRaisedButton_Click);
            }
            public class subject
            {
                Form1 frm;
                public void changeTab(int tabPage/* , Form1 frm1 */, Form1 frm1)
                {
                    frm = frm1;
                    frm.TabControlSubjects.SelectTab(tabPage);
                }
            }
            const string buttonPrefix = "materialRaisedButton";
            private void materialRaisedButton_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                string name = button.Text;
                int number = int.Parse(name.Substring(buttonPrefix.Length));
                subject1.changeTab(number, this);
            }
        }
     
    }​
