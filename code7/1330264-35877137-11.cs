    void Render (MimeMessage message)
    {
        var visitor = new HtmlPreviewVisitor ();
    
        message.Accept (visitor);
    
        plhMessage.Controls.Add (new LiteralControl (visitor.HtmlBody));
    }
