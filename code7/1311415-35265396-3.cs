     public partial class Form1 : Form
        {
                private bool _record;
                private bool _selecting;
            ADBShell adbshell;
                private Rectangle _selection;
        
                //---------------------------------------------------------------------
                public Form1()
                {
                    InitializeComponent();
                    adbshell = new ADBShell();
                }
        
                //---------------------------------------------------------------------
        private void Form1_Load(object sender, System.EventArgs e)
        {
          
          adbshell.Start_ADBShell();
        
        }
