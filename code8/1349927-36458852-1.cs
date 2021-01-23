    public void ShowLoading()
    {
     loadingPDF.Show(); // Show the loading form 
     System.ComponentModel.BackgroundWorker worker = new BackgroundWorker();
     worker.DoWork += worker_DoWork;
     worker.RunWorkerCompleted += worker_RunWorkerCompleted;
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       //anything you want to do AFTER the cpu-intensive process is done
       loadingPDF.Hide(); // Hide the loading form 
    }
    public void worker_DoWork(object sender, DoWorkEventArgs e)
    {
     string fileDate = DateTime.Now.ToString("dd-MM-yy");
     string fileTime = DateTime.Now.ToString("HH.mm.ss");
     string outcomeFolder = outputFolder;
     string outputFile = "Combined Folder " + fileDate + " @ " + fileTime + ".pdf";
     string outputFileName = Path.Combine(outcomeFolder, outputFile);
     // combines the file name, output path selected and the yes / no for pagebreaks. 
     PDFMerge.CombineMultiplePDFs(sourceFiles, outputFileName);
     
    }
