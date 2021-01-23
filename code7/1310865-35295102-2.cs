          public void printCanvas()
          {
             XpsDocument doc = new XpsDocument(@".\canvas.xps", System.IO.FileAccess.Write);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
            // The size of the canvas
            System.Windows.Size size = new System.Windows.Size(cmToWpf(102), cmToWpf(6));
            // Arrange canvas           
            canvas.Arrange(new Rect(size));
            writer.Write(canvas);
            doc.Close();
        }
