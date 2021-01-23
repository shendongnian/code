    public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      var inputFilePath = "input file path";
      var outputFilePath = "output file Path";
      using (var sr = new StreamReader(inputFilePath))
      {
        int counter = 0;
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          // do all the important stuff
    
          counter++;
          // report progress after every 100 lines
          // reporting too often can essentially lock the UI by continuously updating it
          if (counter % 100 == 0)
            backgroundWorker1.ReportProgress(counter);
        }
      }
    }
