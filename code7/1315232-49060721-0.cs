    using (var engine = new Engine())
    {
        var mp4 = new MediaFile { Filename = mp4FilePath };
        engine.GetMetadata(mp4);
        var i = 0;
        while (i < mp4.Metadata.Duration.Seconds)
        {
            var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
            var outputFile = new MediaFile { Filename = string.Format("{0}\\image-{1}.jpeg", outputPath, i) };
            engine.GetThumbnail(mp4, outputFile, options);
            i++;
        }
    }
