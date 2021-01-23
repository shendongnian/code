    // Read the image stream
    using (var originalFile = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
    {
        // Create the bitmap decoder
        decoder = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);
    
        // The the first frame contains the image metadata
        var bitmapFrame = decoder.Frames[0];
    
        if (bitmapFrame != null && bitmapFrame.Metadata != null)
        {
            // To be able to modify the metadata, first we need to clone it
            BitmapMetadata metadata = bitmapFrame.Metadata.Clone() as BitmapMetadata;
    
            // Remove the XP Subject field
            metadata.RemoveQuery("System.Subject");
    
            // Remove the XP keyword field
            metadata.RemoveQuery("System.Keywords");
    
            // Write Tags (Lightroom keywording)
            var keywords = "K1; K2; K3";
            var keywordArray = keywords.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
    
            // Write in the XMP section
            metadata.SetQuery("/xmp/dc:Subject", new BitmapMetadata("xmpbag"));
            for (var i = 0; i < keywordArray.Length; i++)
            {
                var order = "/{ulong=" + i + "}";
                var keyword = keywordArray[i];
                metadata.SetQuery("/xmp/<xmpbag>dc:Subject" + order, keyword);
            }
    
            // Write in the IPTC section
            metadata.SetQuery("/app13/irb/8bimiptc/iptc/{str=Keywords}", keywordArray);
    
            // Create a bitmap encoder
            var encoder = CreateBitmapEncoder(imageFormat);
    
            // Create new frame with the updated metadata
            // Keep everything the same except the updated metadata
            encoder.Frames.Add(BitmapFrame.Create(
                bitmapFrame, bitmapFrame.Thumbnail, metadata, bitmapFrame.ColorContexts));
    
            // Attemp to save the update image
            using (Stream outputFile = File.Open(path + tempSufix, FileMode.Create, FileAccess.ReadWrite))
            {
                encoder.Save(outputFile);
            }
        }
    }
