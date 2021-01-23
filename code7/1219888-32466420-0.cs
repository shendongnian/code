    private void startAsyncButton_Click(object sender, EventArgs e)
    {
       if(backgroundWorkerA.IsBusy != true)
       {
          //start the Async Thread
          backgroundWorkerA.RunWorkerAsync();
       }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
       StreamReader file = new StreamReader(@"C:\Users\User\Documents\Files.txt");
       while ((line = file.ReadLine()) != null)
       {
           richTextBox1.Text += Environment.NewLine + "Copying: " + line;
           counter++;
           Thread.Sleep(1000);
       }
    }
