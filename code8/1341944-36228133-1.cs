    private async void MyButton_Click(object sender, EventArgs e)
    {
        foreach (var item in items)
        {
            // assuming C# 5 closure semantics
            await Task.Run(() => doWork(item));
            // update the UI using the result
        }
    }
