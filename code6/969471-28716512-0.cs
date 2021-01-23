    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form_Load);
        }
        private void Form_Load(object sender, EventArgs e)
        {
            AxShockwaveFlash player = new AxShockwaveFlash();
            player.CreateControl();
            player.WMode = "transparent";
            player.AllowScriptAccess = "sameDomain";
            player.Loop = false;
            player.LoadMovie(0, @"encrypt.swf");
        }
    }
