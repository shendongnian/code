    listBox1.Items.Clear();
    Task.Run(() =>
    {
        listBox1.Invoke(new Action(() => { listBox1.Items.Add("3"); }));
        System.Threading.Thread.Sleep(1000);
    }).ContinueWith(x =>
    {
        listBox1.Invoke(new Action(() => { listBox1.Items.Add("2"); }));
        System.Threading.Thread.Sleep(1000);
    }).ContinueWith(x =>
    {
        listBox1.Invoke(new Action(() => { listBox1.Items.Add("1"); }));
        System.Threading.Thread.Sleep(1000);
    });
