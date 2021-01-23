    internal MemoryStream ResizePDF(HttpPostedFileBase file)
    {
        string inputFilePath = String.Format(@"{0}", file.FileName);
        GhostscriptPipedOutput gsPipedOutput = new GhostscriptPipedOutput();
        string outputPipeHandle = "%handle%" + int.Parse(gsPipedOutput.ClientHandle).ToString("X2");
        MemoryStream memStream = null;
        using (GhostscriptProcessor processor = new GhostscriptProcessor())
        {
            try
            {
                processor.Process(GetGsArgs(inputFile, outputPipeHandle));
                byte[] rawDocumentData = gsPipedOutput.Data;
                memStream = new MemoryStream(rawDocumentData);
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
        return memStream;
    }
    private string[] GetGsArgs(string inputFilePath, string outputFilePath)
    {
            List<string> switches = new List<string>();
            switches.Add("-empty");
            switches.Add("-dQUIET");
            switches.Add("-dSAFER");
            switches.Add("-dBATCH");
            switches.Add("-dNOPAUSE");
            switches.Add("-dNOPROMPT");
            switches.Add("-dPDFSETTINGS=/ebook");
            switches.Add("-sDEVICE=pdfwrite");
            switches.Add("-sPAPERSIZE=a4");
            switches.Add("-sOutputFile=" + outputPipeHandle);
            switches.Add("-f");
            switches.Add(inputFilePath);
            return switches.ToArray();
    }
