    for(int i = 0; i < frameCount; i++)
    {
        img.SelectActiveFrame(dimension, i);
        var outputPath = myFolder + "/frame_"+i+".png";
        using (var memory = new MemoryStream())
        {
            img.Save(memory, ImageFormat.Png); // cloning is not necessary
            File.WriteAllBytes(outputPath, memory.ToArray());
        }
    }
