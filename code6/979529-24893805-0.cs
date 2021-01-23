    private void button1_Click(object sender, RoutedEventArgs e)
    {
        DoSomethingAsync();
    }
    
    private async void DoSomethingAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            await doSomething(i);
        }
    }
    
    async Task doSomething(int i)
    {
        await Task.Delay(1000);
        textBox1.Text += "this is the " + i + "th line\n";
    }
