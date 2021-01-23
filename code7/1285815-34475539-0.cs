    void Stamp(PdfContentByte cb, Rectangle rect, BaseFont bf, string text)
    {
        int altitude = Math.Max(bf.GetAscent(text), bf.GetDescent(text));
        int width = bf.GetWidth(text);
        double horizontalFit = Math.Sqrt(2.0) * 1000 * (rect.Left + rect.Right) / (width + 2 * altitude);
        double verticalFit = Math.Sqrt(2.0) * 1000 * (rect.Bottom + rect.Top) / (width + 2 * altitude);
        double fit = Math.Min(horizontalFit, verticalFit);
        cb.BeginText();
        cb.SetColorFill(CMYKColor.RED);
        cb.SetFontAndSize(bf, (float) fit);
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text, (rect.Right + rect.Left) / 2, (rect.Top + rect.Bottom) / 2, 45);
        cb.EndText();
    }
