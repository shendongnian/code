        private Gates _gate;
        public Form1()
        {
            InitializeComponent();
            _gate = new Gates();
            _gate.OnStatusChanged += gate_OnStatusChanged; //setup event handler
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox3.Enabled = false;
        }
        void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            _gate.InputA = checkBox2.Checked;
        }
        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _gate.InputB = checkBox1.Checked;
        }
        void gate_OnStatusChanged(Gates gates, CustomEvent e)
        {
            checkBox3.Checked = e.Stat;
        }
