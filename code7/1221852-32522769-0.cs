    if (Clipboard.ContainsAudio())
    {
    	var audio = Clipboard.GetAudioStream();
    	[..]
    }
    
    if (Clipboard.ContainsFileDropList())
    {
    	var list = Clipboard.GetFileDropList();
    	[..]
    }
    
    if (Clipboard.ContainsImage())
    {
    	var image = Clipboard.GetImage();
    	[..]
    }
    
    
    if (Clipboard.ContainsText(TextDataFormat.Html))
    {
    	var text = Clipboard.GetText(TextDataFormat.Html);
    	[..]
    }
