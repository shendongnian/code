    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                // Default Constractor.
                new Form1();
                // Secound Constractor.
                new Form1(new List<Test>());
            }
        }
    }
