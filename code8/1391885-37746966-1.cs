    public void ConvertFileWithLame(string pathToLame, string fileToConvert){
         // Use ProcessStartInfo class.
         ProcessStartInfo startInfo = new ProcessStartInfo(pathToLame, fileToConvert);
         try{
              // Start the process with the info we specified.
              // Call WaitForExit and then the using-statement will close.
              using (Process exeProcess = Process.Start(startInfo)){
                   exeProcess.WaitForExit();
              }
         }
         catch{
              // Log error.
         }
    }
