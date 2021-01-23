    void button1_Click(object sender, EventArgs e)
    {
        AAA();
    }
    private List<string> stacks = new List<string>();
    async Task BBB(int delay)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay));
        var stack = new StackTrace().ToString();
        stacks.Add(stack);
        MessageBox.Show(stack);
    }
    async Task AAA()
    {
        var task1 = BBB(1);  // <--- notice delay=1;  
        var task2 = BBB(1);  // <--- notice delay=1;  
        var task3 = BBB(1);  // <--- notice delay=1;  
        await Task.WhenAll(task1, task2, task3);
        Clipboard.SetText(string.Join("\r\n\r\n", stacks));
    }
