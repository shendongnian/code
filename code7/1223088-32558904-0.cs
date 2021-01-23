    async Task BBB(SharedData data)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine(data.Value);
        MessageBox.Show(data.Value.ToString());
        data.Value = data.Value + 1;
    }
