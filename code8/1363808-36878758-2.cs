    public class MainForm : Form
    {
        private Timer timer = new Timer() { Interval = 1000 };
        public MainForm()
        {
            /* other initializations */
            timer.Enabled = false;
            timer.Tick += timer_Tick;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            globalVars.spacerunning = !globalVars.spacerunning;
            timer.Enabled = globalVars.spacerunning;
        }
    }
