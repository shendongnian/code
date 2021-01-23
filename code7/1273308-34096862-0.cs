            private void option1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl1 ctl1 = new UserControl1();
            menuPanel.Controls.Add(ctl1);
            ctl1.btn1Click += new EventHandler(btn1_Click);
            UserControl2 ctl2 = new UserControl2();
            mainPanel.Controls.Add(ctl2);
        }
