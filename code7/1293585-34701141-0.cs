    private void Button1_Click(object sender, EventArgs e)
           {
            MyUserControl MainPanelControls = new MyUserControl();
            MainPanel.SuspendLayout();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(MainPanelControls);             
            MainPanel.ResumeLayout();
           }
