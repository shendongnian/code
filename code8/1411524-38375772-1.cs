    public async Task DoWorkAsync(string text, string file)
    {
        using(FileStream sourceStream = new FileStream(file, FileMode.Create, FileAccess.Write))
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }
    }
    IEnumerable<string> fileNames = new string[] { "file1.txt", "file2.txt" };
    Task[] writingTasks = fileNames
                              .Select(fileName => DoWorkAsync("some text", fileName))
                              .ToArray();
    await Task.WhenAll(writingTasks);
