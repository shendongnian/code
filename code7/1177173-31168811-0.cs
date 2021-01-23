    int y = 0;
    string allLines = @"read the whole file into 'string'";
    Regex RxCounter = new Regex(@"(?m)^CLM");    // Unsing (?m) multi-line modifier option, inline.
                                                 // If Dot-Net does not recognise this inline option
                                                 // set it in the options field of the constructor.
    Match _m = RxCounter.Match( allLines );
    while (_m.Success)
    {
        y++;
        (xlRange.Cells[startRow + x, 3] as Excel.Range).Value2 = y;
    	_m = _m.NextMatch();
    }
