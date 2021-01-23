    public void button1_Click(object sender, EventArgs e)
    {
        Console.WriteLine("before waiting");
        DoSomethingThatTakes2Seconds();
        Console.WriteLine("after waiting");
    }
