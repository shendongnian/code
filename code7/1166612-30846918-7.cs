    public static Task MyTestMain(IProgress<string> pProgress)
    {
        return SomethingAsync(pProgress);
    }
    async void BtnGo_Click(object sender, System.EventArgs e)
    {
        label2.Text = @"Starting tasks...";
        var progress = new Progress<string>(
            p =>
            {
                label2.Text = p;
            });
        await TestTask.MyTestMain(progress);
    }
