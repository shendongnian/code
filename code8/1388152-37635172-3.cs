    private async void button1_Click(object sender, EventArgs e)
    {
        var t = FooAsync();
        ...
        var s = await t;
        button1.Text = s;
    }
    public async Task<string> FooAsync()
    {
        var something = await Task.Run(() => DoCPUIntensiveNonUIStuff());
       DoSomeUIWork();
       return ...
    }
