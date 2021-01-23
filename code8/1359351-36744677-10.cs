    var size = new Size(1600, 1200);                    // The desired size of the video
    var fps = 25;                                       // The desired frames-per-second
    var codec = VideoCodec.MPEG4;                       // Which codec to use
    var destinationfile = @"d:\myfile.avi";             // Output file
    var srcdirectory = @"d:\foo\bar";                   // Directory to scan for images
    var pattern = "*.jpg";                              // Files to look for in srcdirectory
    var searchoption = SearchOption.TopDirectoryOnly;   // Search Top Directory Only or all subdirectories (recursively)?
    using (var writer = new VideoFileWriter())          // Initialize a VideoFileWriter
    {
        writer.Open(destinationfile, size.Width, size.Height, fps, codec);              // Start output of video
        foreach (var file in Directory.GetFiles(srcdirectory, pattern, searchoption))   // Iterate files
        {
            using (var original = (Bitmap)Image.FromFile(file))     // Read bitmap
            using (var resized = new Bitmap(original, size))        // Resize if necessary
                writer.WriteVideoFrame(resized);                    // Write frame
        }
        writer.Close();                                 // Close VideoFileWriter
    }                                                   // Dispose VideoFileWriter
