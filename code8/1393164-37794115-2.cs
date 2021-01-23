    public class MainForm:Form
    {
        public MainForm()
        {
            UserControl1.MessageHasSent +=SetToolStripLabel;
        }
        public  SetToolStripLabel( object sender,string e)
        {
            //Set e to Label
        }
    }
    
