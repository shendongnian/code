    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private List<Test> _property;
    
            public Form1()
            {
                InitializeComponent();
            }
            public Form1(List<Test> valueList)
            {
                _property = valueList;
                InitializeComponent();
            }
        }
    
        public class Test
        {
            public int Id { get; set; }
            private string Name { get; set; }
        }
    }
