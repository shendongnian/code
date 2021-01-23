    static void Main()
    {
        f = new Form1(); // form instance is created
        f.progressBar1.Maximum = 100;
        f.progressBar1.Minimum = 0;
        f.progressBar1.Value = 0;
        // create and start task running in parallel
        Task.Run(() =>
        {
            Thread.Sleep(3000); // wait long enough until form is displayed
            updateProgress(25);
            updateProgress(50);
        });
        Application.Run(f);
    }
    public static void updateProgress(int x)
    {
        // Invoke is required because we run it in another thread
        f.Invoke((MethodInvoker)(() => 
        {
            Program.f.progressBar1.Visible = true;
            Program.f.progressBar1.Enabled = true;
            Program.f.progressBar1.Value +=x;
        }));
        Thread.Sleep(5000); // simulate work
    }
