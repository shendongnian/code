    internal PdfPage(PdfDictionary dict)
        : base(dict)
    {
        // Set Orientation depending on /Rotate.
        //int rotate = Elements.GetInteger(InheritablePageKeys.Rotate);
        //if (Math.Abs((rotate / 90)) % 2 == 1)
        //    _orientation = PageOrientation.Landscape;
    }
