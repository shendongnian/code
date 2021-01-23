    MemoryStream ms = new MemoryStream();  
    myImage.Save(ms,myImage.RawFormat);
    ms.Seek(0, SeekOrigin.Begin);  
    BitmapImage bi = new BitmapImage();  
    
    bi.BeginInit();
    bi.CacheOption = BitmapCacheOption.OnLoad;
    bi.St
    reamSource = ms;  
    bi.EndInit();
    
    using(var vis = new DrawingVisual())
    {
        var dc = vis.RenderOpen();
        dc.DrawImage(bi, new Rect { Width = bi.Width, Height = bi.Height });
        dc.Close();
        var pdialog = new PrintDialog();
        if (pdialog.ShowDialog() == true)
        {
            pdialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
            System.Printing.ValidationResult result = pdialog.PrintQueue.MergeAndValidatePrintTicket(pdialog.PrintQueue.UserPrintTicket, pdialog.PrintTicket);
            pdialog.PrintQueue.CurrentJobSettings.CurrentPrintTicket = result.ValidatedPrintTicket;
            pdialog.PrintQueue.Commit();
            if(pdialog.PrintQueue.IsXpsDevice)
            {
                var writer = PrintQueue.CreateXpsDocumentWriter(pdialog.PrintQueue);
                writer.Write(vis, pdialog.CurrentJobSettings.CurrentPrintTicket);
            }
            else
            {
                pdialog.PrintVisual(vis, "My Image");
            }
        }
    }
