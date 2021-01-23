       public async Task<IActionResult> GetFile()
       {
        ...
            return await _fileManager.GetFileAsync(this, "filename", mimeType);
        }
