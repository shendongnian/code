        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(new Button() { Top = panel1.Controls.Count * 30 });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
            panel1.Refresh();
        }
