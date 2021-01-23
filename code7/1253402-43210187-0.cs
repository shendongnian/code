    var html = "<!DOCTYPE html><html><head></head><body><style type=\"text/css\">.SQLCode{font-size:13px;font-weight:bold;font-family:monospace;;white-space:pre;-o-tab-size:4;-moz-tab-size:4;-webkit-tab-size:4;}.SQLComment{color:#00AA00;}.SQLString{color:#AA0000;}.SQLFunction{color:#AA00AA;}.SQLKeyword{color:#0000AA;}.SQLOperator{color:#777777;}.SQLErrorHighlight{background-color:#FFFF00;}</style><pre class=\"SQLCode\"><span class=\"SQLComment\">--Example Commend</span><span class=\"SQLKeyword\">SELECT</span><span class=\"SQLKeyword\">TOP</span> 1 <span class=\"SQLFunction\">COALESCE</span><span class=\"SQLOperator\">(</span>ASPU<span class=\"SQLOperator\">.</span>MobileAlias<span class=\"SQLOperator\">,</span> ASPU<span class=\"SQLOperator\">.</span>UserName<span class=\"SQLOperator\">)</span><span class=\"SQLKeyword\">AS</span> UName<span class=\"SQLKeyword\">FROM</span> dbo<span class=\"SQLOperator\">.</span>aspnet_Users ASPU</pre></body></html>";
    var title = "Header Text";
    if (!string.IsNullOrWhiteSpace(html))
    {
        var web = new WebBrowser();
        web.CreateControl();
        web.DocumentText = html;
        while (web.DocumentText != html)
        {
            System.Windows.Forms.Application.DoEvents();
        }
        web.Document.ExecCommand("SelectAll", false, null);
        web.Document.ExecCommand("Copy", false, 
        //Start here if you already have it in RTF.
        var rtf = Clipboard.GetData(DataFormats.Rtf) as string;
        if (!string.IsNullOrWhiteSpace(rtf))
        {
            slide = ppt.Slides.AddSlide(ppt.Slides.Count + 1, ppt.SlideMaster.CustomLayouts[1]);
            slide.Layout = PpSlideLayout.ppLayoutTextAndObject;
            slide.Shapes.Title.TextFrame.TextRange.Text = title;
            slide.Select();
            slide.Shapes[2].Select();
            Globals.ThisAddIn.Application.CommandBars.ExecuteMso("PasteSourceFormatting");
            System.Windows.Forms.Application.DoEvents();
        }
    }
