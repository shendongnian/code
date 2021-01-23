    public void ShowLoading()
    {
     loadingPDF.Shown += loadingPDF_Shown;
     loadingPDF.Show(); // Show the loading form
    }
    public void loadingPDF_Shown(object sender, eventargs e)
    {
     string fileDate = DateTime.Now.ToString("dd-MM-yy");
     string fileTime = DateTime.Now.ToString("HH.mm.ss");
     string outcomeFolder = outputFolder;
     string outputFile = "Combined Folder " + fileDate + " @ " + fileTime + ".pdf";
     // combines the file name, output path selected and the yes / no for pagebreaks. 
     PDFMerge.CombineMultiplePDFs(sourceFiles, outputFileName);
     loadingPDF.Hide(); // Hide the loading form 
    }
