    using PPT = Microsoft.Office.Interop.PowerPoint;
    
            public void Main()
            {
                PPT.Application app = new PPT.Application();
                app.Visible = MsoTriState.msoCTrue;
                PPT.Presentation ppt1 = app.Presentations.Open(@"C:\Presentation1.pptx");
                ppt1.Slides[1].Copy();
    
                PPT.Presentation ppt2 = app.Presentations.Open(@"C:\Presentation2.pptx");
                ppt2.Windows[1].View.GotoSlide(1);
    
                app.CommandBars.ExecuteMso("PasteSourceFormatting");
    
            }
