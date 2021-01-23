    Bitmap imaageBitmap; // = wherever your image comes from
    
    using (var stream = new MemoryStream())
    {
        imageBitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
        stream.Seek(0, SeekOrigin.Begin);
        var visionServiceClient = new VisionServiceClient("YOUR_API_KEY");
        var visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
        var result = await visionServiceClient.AnalyzeImageAsync(stream, visualFeatures);
    }
