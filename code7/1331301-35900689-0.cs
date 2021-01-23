        . . .
        var logoRange = _xlSheet.Range[
            _xlSheet.Cells[LOGO_FIRST_ROW, _grandTotalsColumn-1], _xlSheet.Cells[LOGO_LAST_ROW, _grandTotalsColumn]];
        PlacePicture(_logo, logoRange);
    }
    
    // From Jürgen Tschandl
    private void PlacePicture(Image picture, Range destination)
    {
        Worksheet ws = destination.Worksheet;
        Clipboard.SetImage(picture);
        ws.Paste(destination, false);
        Pictures p = ws.Pictures(System.Reflection.Missing.Value) as Pictures;
        Picture pic = p.Item(p.Count) as Picture;
        ScalePicture(pic, (double)destination.Width, (double)destination.Height);
    }
    
    // Also from Jürgen Tschandl
    private void ScalePicture(Picture pic, double width, double height)
    {
        double fX = width / pic.Width;
        double fY = height / pic.Height;
        double oldH = pic.Height;
        if (fX < fY)
        {
            pic.Width *= fX;
            if (pic.Height == oldH) // no change if aspect ratio is locked
                pic.Height *= fX;
            pic.Top += (height - pic.Height) / 2;
        }
        else
        {
            pic.Width *= fY;
            if (pic.Height == oldH) // no change if aspect ratio is locked
                pic.Height *= fY;
            pic.Left += (width - pic.Width) / 2;
        }
    }
