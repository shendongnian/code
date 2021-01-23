    > var re = new Regex(@"(\d) (\d)");
    > var r = re.Match("5 6").Groups;
    > r[0]
    {5 6}
        [System.Text.RegularExpressions.Match]: {5 6}
        base {System.Text.RegularExpressions.Capture}: {5 6}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
    > r[1]
    {5}
        base {System.Text.RegularExpressions.Capture}: {5}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
    > r[2]
    {6}
        base {System.Text.RegularExpressions.Capture}: {6}
        Captures: {System.Text.RegularExpressions.CaptureCollection}
        Success: true
