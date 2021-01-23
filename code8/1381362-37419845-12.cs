    public async void button1_Click(object sender, EventArgs e)
    {
        Console.WriteLine("before awaiting");
        await GetSomethingAsync();
        Console.WriteLine("after awaiting");
    }
