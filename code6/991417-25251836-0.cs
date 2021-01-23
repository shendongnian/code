    public class PipedOutputSample
    {
        public void Start()
        {
            string inputFile = @"E:\gss_test\test_postscript.ps";
    
            GhostscriptPipedOutput gsPipedOutput = new GhostscriptPipedOutput();
    
            // pipe handle format: %handle%hexvalue
            string outputPipeHandle = "%handle%" + int.Parse(gsPipedOutput.ClientHandle).ToString("X2");
    
            using (GhostscriptProcessor processor = new GhostscriptProcessor())
            {
                List<string> switches = new List<string>();
                switches.Add("-empty");
                switches.Add("-dQUIET");
                switches.Add("-dSAFER");
                switches.Add("-dBATCH");
                switches.Add("-dNOPAUSE");
                switches.Add("-dNOPROMPT");
                switches.Add("-sDEVICE=pdfwrite");
                switches.Add("-o" + outputPipeHandle);
                switches.Add("-q");
                switches.Add("-f");
                switches.Add(inputFile);
    
                try
                {
                    processor.StartProcessing(switches.ToArray(), null);
    
                    byte[] rawDocumentData = gsPipedOutput.Data;
    
                    //if (writeToDatabase)
                    //{
                    //    Database.ExecSP("add_document", rawDocumentData);
                    //}
                    //else if (writeToDisk)
                    //{
                    //    File.WriteAllBytes(@"E:\gss_test\output\test_piped_output.pdf", rawDocumentData);
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    gsPipedOutput.Dispose();
                    gsPipedOutput = null;
                }
            }
        }
    }
