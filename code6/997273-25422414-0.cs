    private async void button1_Click(object sender, EventArgs e)
    {
        var progress=new Progress<string>(msg=>textBox1.Text = msg);
        await Task<string>.Factory.StartNew(() => Foo(progress));
    }
    private void Foo(IProgress<string> progress)
    {
        for (int i = 0; i < 100; i++)
        {
            progress.OnReport(i.ToString());
            Thread.Sleep(1000);
        }
        progress.OnReport("Finished");
    }
    
