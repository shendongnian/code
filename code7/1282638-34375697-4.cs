    void main(string[] args) {
       var inputFileName= DetermineInputFileName(args);
        var outputFileName= DetermineOutputFileName(args);
       ReadAndWriteFile(inputFileName, outputFileName)
    }
    void ReadAndWriteFile(string inputFileName, string outputFileName) {
      //only use the streamreader here
       using(var inputFile = new StringReader) {
          using (var outputFile = new StringWriter) {
             do {
                 string line = String.Empty;
                 do {
                  var input = inputFile.ReadLine();
                  line += input;
                 while (ContinueReadingAfterThisInput(input))
                 var processedLine = Process(line);
                 outputFile.WriteLine(processedLine);
             }
          }
       }
      
    }
