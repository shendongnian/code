    private void button1_Click(object sender, EventArgs e)
    {
        Task.Run(() =>
        {
            Thread.Sleep(2000);
            Invoke(new Action((CloseMessageBox));
        });
        ShowMessageBox();
    }
