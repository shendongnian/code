    private async void button1_Click(object sender, EventArgs e)
    {
        frmProgressBar frmProgressBarObj = await Task.Run(() =>
                          PullMSI.ExtractByMSIName("products.txt", false));
        MessageBox.Show(string.Format("Returned {0}", frmProgressBarObj.ToString());
    }
