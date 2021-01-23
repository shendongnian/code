        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Test");
            tabControl1.TabPages.Add(tp);
            TextBox tb = new TextBox();
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tp.Controls.Add(tb);
        }
