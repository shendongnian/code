    private async void button1_Click(object sender, EventArgs e)
    {
    byte[] dec = File.ReadAllBytes(@"filepath");
    DateTime fdate = offset.AddDays(dateadd);
    int[] telemetry = { 1, 2, 3 };
    DateTime test1 = DateTime.Now;
    Parallel.ForEach (telemetry,tm=>
    {
        using(StreamWriter writer = new StreamWriter("outputpath"+tm.ToString()+".txt", true))
        {
        //DO PROCESSING
        }
    });
    DateTime test2 = DateTime.Now;
    draw(telemetry);
    Console.WriteLine(test2.Subtract(test1));
    }
