        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread newThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadProcSafe));
            newThread.Start();
        }
        private void ThreadProcSafe()
        {
            this.SetText();
        }
        private void SetText()
        {
            if (textBox1.InvokeRequired)
			{
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d);
                
            }
            else
            {
                while (1 < 3)
                {
                    textBox1.Text += "1";
                    textBox1.Refresh();
                }
            }
        }
