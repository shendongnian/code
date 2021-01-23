    MainForm frmMain = new MainForm();
    InfoForm frmInfo = new InfoForm();
    public void ShowMain()
    {
        frmMain.GoBtn.Click += GoBtn_Click;
        frmInfo.BackBtn.Click += BackBtn_Click;
        frmMain.ShowDialog();
    }
    private void GoBtn_Click(object sender, EventArgs e)
    {
        frmInfo.StartPosition = FormStartPosition.CenterParent;
        frmInfo.Show(sender as Form);
    }
    private void BackBtn_Click(object sender, EventArgs e)
    {
        frmInfo.Hide();
    }
