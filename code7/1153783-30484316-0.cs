        public void LoadImage(string InputPDFFile,int PageNumber)
        {
            string outImageName = Path.GetFileNameWithoutExtension(InputPDFFile);
            outImageName = outImageName+"_"+PageNumber.ToString() + "_.png";
                
            GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.Png256);
            dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            dev.ResolutionXY = new GhostscriptImageDeviceResolution(290, 290);
            dev.InputFiles.Add(InputPDFFile);
            dev.Pdf.FirstPage = PageNumber;
            dev.Pdf.LastPage = PageNumber;
            dev.CustomSwitches.Add("-dDOINTERPOLATE");
            dev.OutputPath = Server.MapPath(@"~/tempImages/" + outImageName);
            dev.Process();
        }
  
