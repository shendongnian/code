    private void cb_Stop_Click(object sender, EventArgs e)
    {
        stopped = true;   // this will be checked in our output loop
    }
    private void cb_Start_Click(object sender, EventArgs e)
    {
        stopped = false;
        // create my test data..
        List<double> data = new List<double>();
        for (int i = 0; i < 10000000; i++) data.Add((i+ 1d) / i * 1d );
        string filename = "D:\\xxxxx.txt";
        // this is an optional callback to provide feedback. 
        //It obviuosly slows things down greatly..
        Action<int> callback = (value) => st_lines.Invoke(new Action(() 
                             => st_lines.Text = value + "lines written.."));
        // now we start the write loop in another task..
        // ..passing in our data and (optinally) the callback
        Task myFirstTask = Task.Factory.StartNew(() 
                         => Write(data.ToArray(), filename, callback));
    }
    static bool stopped = true;   // our flag
    // your write loop
    public static void Write(double[] data, string outputPath, Action<int> aCallback)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.GetLength(0); i++)
        {
            if (stopped) break;   // our new test
            sb.AppendLine(string.Join(",", data[i]));
            aCallback( i );       // optional callback
        }
        File.WriteAllText(outputPath, sb.ToString());
    }
