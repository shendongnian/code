    using System;
    using System.Windows.Forms;
    
    namespace textBoxs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Subscribe();
            }
    
            private event Action ClearAll;
    
            void Subscribe()
            {
                ClearAll += tbA.Clear;
                ClearAll += tbB.Clear;
                ClearAll += tbC.Clear;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ClearAll();
            }
        }
    }
