        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input1 = Interaction.InputBox("Type contents of label:");
            Label lbl = new Label();
            lbl.Text = input1;
            lbl.AutoSize = true;
            flowLayoutPanel1.Controls.Add(lbl);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
            }
        }
