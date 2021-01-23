        public partial class Form1 : Form
        {
            Timer t = new Timer();
            int duration = 0;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            void t_Tick(object sender, EventArgs e)
            {
                if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition >= duration)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    duration = 0;//reset it...
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                duration = 10;/* get the value from wherever you need to...*/
                axWindowsMediaPlayer1.URL = @"E:\music\Mike Terrana\Shadows of the Past\01 Pleasure Cube.mp3";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                t.Interval = 500;
                t.Tick += new EventHandler(t_Tick);
                axWindowsMediaPlayer1.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(axWindowsMediaPlayer1_OpenStateChange);
            }
    
            void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
            {
                if (axWindowsMediaPlayer1.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                {
                    t.Start();
                }
            }
    
        }
