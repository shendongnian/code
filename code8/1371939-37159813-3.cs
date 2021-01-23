     private class CellEvents : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
        {
    
            int scoreCellHeight = 20;
    
            var pdfContentByte = canvases[0];
            pdfContentByte.SaveState();
    
            pdfContentByte.Rectangle(pos.Left, pos.Bottom + scoreCellHeight, pos.Width, pos.Height - scoreCellHeight);
            pdfContentByte.SetColorFill(new BaseColor(233, 240, 242));
            pdfContentByte.Fill();
    
    
            ColumnText ct = new ColumnText(pdfContentByte);
            ct.SetSimpleColumn(new Phrase(_model.Name, _nfSubComp), pos.Left, pos.Bottom + 20, pos.Left + pos.Width, pos.Bottom + pos.Height - 5, 10, Element.ALIGN_CENTER);
            ct.Go();
    
            float scaleWidth = pos.Width / 10;
    
            for (int i = 1; i < 11; i++)
            {
                float scaleLeft = pos.Left + (i - 1) * pos.Width / 10;
    
                pdfContentByte.Rectangle(scaleLeft, pos.Bottom, scaleWidth, scoreCellHeight);
    
                pdfContentByte.SetColorFill(i % 2 == 1
                    ? new BaseColor(Color.LightBlue)
                    : new BaseColor(233, 240, 242));
                pdfContentByte.Fill();
    
    
                ct.SetSimpleColumn(new Phrase(i.ToString(), _nfScale), scaleLeft, pos.Bottom,
                        scaleLeft + scaleWidth, pos.Bottom + 7, 0, Element.ALIGN_CENTER);
                ct.Go();
            }
            canvases[0].RestoreState();
        }
    }
