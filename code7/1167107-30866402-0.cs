            string printerName = "YourPrinterName";
            string inputFile = @"E:\__test_data\test.pdf";
            using (GhostscriptProcessor processor = new GhostscriptProcessor())
            {
                List<string> switches = new List<string>();
                switches.Add("-empty");
                switches.Add("-dPrinted");
                switches.Add("-dBATCH");
                switches.Add("-dNOPAUSE");
                switches.Add("-dNOSAFER");
                switches.Add("-dNumCopies=1");
                switches.Add("-sDEVICE=mswinpr2");
                switches.Add("-sOutputFile=%printer%" + printerName);
                switches.Add("-f");
                switches.Add(inputFile);
                processor.StartProcessing(switches.ToArray(), null);
            }
