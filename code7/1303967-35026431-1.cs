    > var re = new Regex(@"(\d)-([A-Z])");
    > var r = re.Match("5-D").Groups;
    > r[0]
    {5-D}
        [System.Text.RegularExpressions.Match]: {5-D}
        base {System.Text.RegularExpressions.Capture}: {5-D}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
    > r[1]
    {5}
        base {System.Text.RegularExpressions.Capture}: {5}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
    > r[2]
    {D}
        base {System.Text.RegularExpressions.Capture}: {D}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
