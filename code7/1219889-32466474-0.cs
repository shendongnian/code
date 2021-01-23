    System.Threading.ThreadPool.QueueUserWorkItem((obj) =>
    {
        StreamReader file = new StreamReader(@"C:\Users\User\Documents\Files.txt");
        string line;
        int counter = 0;
        while ((line = file.ReadLine()) != null)
        {
            this.Invoke((Action)(() =>
                {
                    richTextBox1.Text += Environment.NewLine + "Copying: " + line;
                }));
            System.Threading.Thread.Sleep(1000);
            counter++;
        }
    });
