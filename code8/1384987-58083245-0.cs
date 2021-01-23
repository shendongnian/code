    public async Task<IActionResult> Download()
    {
        var path = "C:\\test.zip";
        var memory = new MemoryStream();
        using (var stream = new FileStream(path, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;
        return File(memory, GetContentType(path), Path.GetFileName(path));
    }
