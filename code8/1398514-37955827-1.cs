    using (var writer = new VideoFileWriter())
    {
        // create new video file
        writer.Open(Path.Combine(dest_path, "output.avi"), width, height, frameRate, VideoCodec.Raw);
        foreach (string file in Directory.EnumerateFiles(dest_path))
        {
            using(var img = (Bitmap) Image.FromFile(file)) {
                writer.WriteVideoFrame(img);
            }
        }
        writer.Close();
    }
