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
        RichTextBox rtb = new RichTextBox();
        private void button1_Click(object sender, EventArgs e)
        {
            //Capitalize
            rtb.Text = rtb.Text.ToUpper();
            
            
        }
