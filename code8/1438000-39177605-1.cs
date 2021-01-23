    RichTextBox rtb = new RichTextBox();
        private void Form1_Load(object sender, EventArgs e)
        {
            createDynamicRTB();
            rtb.TextChanged += Rtb_TextChanged;//use this to capitalize after leaving
            rtb.KeyPress += Rtb_KeyPress;//use this to capitalize immediately
        }
        private void Rtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            rtb.Text = rtb.Text.ToUpper();
        }
        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            //Capitalize
            rtb.Text = rtb.Text.ToUpper();
        }
        private void createDynamicRTB()
        {
            rtb.Location = new Point(20, 20);
            rtb.Width = 400;
            rtb.Height = 300;
            rtb.BackColor = Color.White;
            rtb.Font = new Font("Mistral", 16, FontStyle.Regular);
            int size = rtb.TextLength;
            rtb.AcceptsTab = true;
            rtb.ScrollBars = RichTextBoxScrollBars.Both;
            rtb.ReadOnly = false;
            rtb.MaxLength = rtb.TextLength;
            rtb.ShortcutsEnabled = true;
            rtb.EnableAutoDragDrop = true;
            Controls.Add(rtb);
        }
