    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Send_ToolStrip_Data_To_Instance_Class()
        {
            My_Other_CS_File other_File = new My_Other_CS_File();
            other_File.Act_On_ToolStrip_Item(checkForUpdatesToolStripMenuItem.Enabled);
        }
    }
    public class My_Other_CS_File
    {
        public void Act_On_ToolStrip_Item(bool enabled)
        {
            //do something
        }
    }
