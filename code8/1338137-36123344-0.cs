    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.TextLength == 5)
        {
            progressBar1.Visible = true;
            int textFromTextBox1 = Int32.Parse(textBox1.Text);
            backgroundWorker1.RunWorkerAsync(textFromTextBox1);
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = FindPrimeNumber((int)e.Argument);
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        textBox2.Text = e.Result.ToString();
        backgroundWorker1.CancelAsync();
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        progressBar1.Visible = false;
    }
