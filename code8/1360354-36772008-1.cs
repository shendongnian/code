        Dictionary<TextBox, Label> textBoxLabelPairing = new Dictionary<TextBox, Label>();
        private void btnMonSub_Click(object sender, EventArgs e)
        {
            TextBox txtMonSub = new TextBox();
            txtMonSub.Name = "MonSub" + CMonSub;
            txtMonSub.Location = new System.Drawing.Point(155 + (100 * CMonSub), 60);
            CMonSub++;
            txtMonSub.Size = new System.Drawing.Size(100, 25);
            //ADDED: keypress event
            txtMonSub.KeyPress += txtMonSub_KeyPress;
            this.Controls.Add(txtMonSub);
            string s = txtMonSub.Text;
            Label l = new Label();
            l.Text = s;
            l.Location = new System.Drawing.Point(155 + (100), 60);
            l.Size = new System.Drawing.Size(100, 25);
            this.Controls.Add(l);
            //ADDED: Dictionary Pairing
            textBoxLabelPairing.Add(txtMonSub, l);
        }
        void txtMonSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if enter key is pressed
            if (e.KeyChar == (char)13)
            {
                TextBox thisTextBox = (TextBox)sender;
                Label associatedLabel = textBoxLabelPairing[thisTextBox];
                associatedLabel.Text = thisTextBox.Text;
            }
        }
