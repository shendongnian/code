       public partial class Form1 : Form
       {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fg = (Form2)Application.OpenForms["Form2"];
            if (fg == null)
            {
                fg = new Form2();
            }
            fg.ShowDialog();
        }
      }
    
     public partial class Form2 : Form
     {
        
        public Form2()
        {
            InitializeComponent();
        }      
        
        private void button1_Click(object sender, EventArgs e)
        {
            var fb = new SaveFileDialog();
            fb.Filter = "xml file (*.xml) | *.xml";
            var res = fb.ShowDialog();            
            if (fb.FileName != null)
            {
                MessageBox.Show(fb.FileName);
                //Manager.DtGabarito.WriteXml(fb.FileName);
                //UpdateAll();
            }
        }       
    }
