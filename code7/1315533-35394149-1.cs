    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace CreateDynamicButtons1_cs
    {
        public partial class Form1 : Form
        {
            private CreateButtons buttons = new CreateButtons("btn");
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                buttons.ParentControl = panel1;
                buttons.Base = 10;
                buttons.BaseAddition = 35;
                buttons.ButtonSize = new Size(50, 25);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    buttons.CreateSingleButton(textBox1.Text);
                }
            }
            private void button2_Click(object sender, EventArgs e)
            {
                if (buttons.Buttons != null)
                {
                    listBox1.DataSource = 
                        buttons.Buttons.Select(item => item.Name).ToList();
                }
            }
        }
    }
