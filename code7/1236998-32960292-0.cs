        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string closemsg = "Do you really want to close the program?";
            const string exit = "Exit";
            DialogResult dialog = MessageBox.Show(closemsg, exit, MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.FormClosing -= Form1_FormClosing;
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
