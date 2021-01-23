    class MyProgressData
    {
        public string Message{get;set;}
        public int Iteration {get;set;}
        public MyProgressData(string message,int iteration) ...
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        var progress=new Progress<MyProgressData>(msg=>{
            textBox1.Text = msg.Message;
            textBox2.Text=msg.Iteration.ToString();
        });
        await Task<string>.Factory.StartNew(() => Foo(progress));
    }
    private void Foo(IProgress<MyProgressData> progress)
    {
        for (int i = 0; i < 100; i++)
        {
            progress.OnReport(new MyProgressData("Hi",i));
            Thread.Sleep(1000);
        }
        progress.OnReport("Finished");
    }
