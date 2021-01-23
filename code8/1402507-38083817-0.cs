    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
             var text = textBox1.Text;
             var progress = new Progress<string>((x) => label1.Text = x);
             await Task.Run(() => DoWork(progress, text));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void DoWork(IProgress<string> progress, string text)
    {
        foreach (string file in Directory.GetFiles("\\\\Mypcname-PC\\vxheaven\\malware"))
        {
            count++;
            progress.Report(Convert.ToString(count));
            if (file.Contains(text))
            {
                progress.Report(Convert.ToString(count) + " reached the file");
                break;
            }
        }
    }
