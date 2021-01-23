    public static void CloseExcel()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        if (_range != null)
        {
            Marshal.FinalReleaseComObject(_range);
            _range = null;
        }
        if (_workSheet != null)
        {
            Marshal.FinalReleaseComObject(_workSheet);
            _workSheet = null;
        }
        if (_workBook != null)
        {
            _workBook.Close(false, String.Empty, false);
            Marshal.FinalReleaseComObject(_workBook);
            _workBook = null;
        }
        if (_application != null)
        {
            try
            {
                _application.Quit();
            }
            Marshal.FinalReleaseComObject(_application);
            _application = null;
        }
    }
    
