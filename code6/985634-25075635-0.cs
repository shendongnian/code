    using System;
    using System.Collections.Generic;
    using System.Text;
    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    using Microsoft.Office.Core;
    
    namespace pptxTOppt
    {
        class Program
        {
            static void Main(string[] args)
            {
                PowerPoint.Application app = new PowerPoint.Application();
                string sourcePptx = @"c:\test.pptx";
                string targetPpt = @"c:\test.ppt";
                object missing = Type.Missing;
                PowerPoint.Presentation pptx = app.Presentations.Open(sourcePptx, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoTrue);
                pptx.SaveAs(targetPpt, PowerPoint.PpSaveAsFileType.ppSaveAsPowerPoint4);
                app.Quit();
            }
        }
    }
