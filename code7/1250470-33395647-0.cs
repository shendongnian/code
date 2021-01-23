    Loading loadingForm = new Loading();
    btnSend_Click(object sender, EventArgs e)
    {
        new Task(() => sendEmail()
        ).Start();
        startLoading();
    }
    public void closeLoading()
    {
        if (loadingForm.InvokeRequired)
        {
            loadingForm.Invoke((MethodInvoker)delegate()
            {
                closeLoading();
            });
        }
        else
        {
            loadingForm.Hide();
        }
    }
    private void startLoading()
    {
        if (loadingForm == null)
        {
            loadingForm = new Loading();
        }
        loadingForm.ShowDialog();
    }
    private void sendEmail()
    {
        Thread.Sleep(1000);
        closeLoading();
    }
