    // Rectangle describes page minus margins.
    Rect rectPage = new Rect(marginPage.Left, marginPage.Top,
      dlg.PrintableAreaWidth - (marginPage.Left + marginPage.Right),
                            dlg.PrintableAreaHeight - (marginPage.Top + marginPage.Bottom));
    // Draw rectangle to reflect user's margins.
    dc.DrawRectangle(null, pn, rectPage);
