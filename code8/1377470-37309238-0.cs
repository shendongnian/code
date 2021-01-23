    void Render (MimeKit.MimeMessage message)
    {
        var tmpDir = Path.Combine(Path.GetTempPath(), message.MessageId);
        var visitor = new HtmlPreviewVisitor(tmpDir);
    
        Directory.CreateDirectory(tmpDir);
    
        message.Accept(visitor);
        // Note: You will need to convert HTML into RTF
        var rtf = ConvertHtmlToRtf (visitor.HtmlBody);
        // Use the Rtf property instead of the Text property because
        // the Text property does not support RTF formatting commands.
        richTextBox1.Rtf = rtf;
    }
