    for(int i = 0; i < count; i++) {
        // Call to Acrobat CopyToClipboard
        // ...
        Clipboard.GetImage().Save(outputPath, ImageFormat.Jpeg);
        Clipboard.Clear();
    
        // ...
    }
