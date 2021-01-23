    public XUnit Height
        {
            get
            {
                PdfRectangle rect = MediaBox;
                //return _orientation == PageOrientation.Portrait ? rect.Height : rect.Width;
                return rect.Height;
            }
            set
            {
                PdfRectangle rect = MediaBox;
                //if (_orientation == PageOrientation.Portrait)
                    MediaBox = new PdfRectangle(rect.X1, 0, rect.X2, value);
                //else
                //    MediaBox = new PdfRectangle(0, rect.Y1, value, rect.Y2);
                _pageSize = PageSize.Undefined;
            }
        }
    public XUnit Width
        {
            get
            {
                PdfRectangle rect = MediaBox;
                //return _orientation == PageOrientation.Portrait ? rect.Width : rect.Height;
                return rect.Width;
            }
            set
            {
                PdfRectangle rect = MediaBox;
                //if (_orientation == PageOrientation.Portrait)
                    MediaBox = new PdfRectangle(0, rect.Y1, value, rect.Y2);
                //else
                //    MediaBox = new PdfRectangle(rect.X1, 0, rect.X2, value);
                _pageSize = PageSize.Undefined;
            }
        }
