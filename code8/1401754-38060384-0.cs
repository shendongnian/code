    void HideTextFileIntoImage(string TextPath, string ImagePath, string NewFilePath)
    {
        var textBytes = File.ReadAllBytes(TextPath);
        var imageBytes = File.ReadAllBytes(ImagePath);
        using (var stream = new FileStream(NewFilePath, FileMode.Create)) {
            stream.Write(imageBytes, 0, imageBytes.Length);
            stream.Write(textBytes, 0, textBytes.Length);
        }
    }
