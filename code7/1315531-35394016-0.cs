        private void button1_Click(object sender, EventArgs e)
        {
            Button newButton = new Button();
            newButton.Location = new System.Drawing.Point(0, buttons[i -1].Location.Y + 26);
            i++;
            buttons.Add(newButton);
            panel1.Controls.Add(newButton);
        }
