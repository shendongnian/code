    public async Task<FileStreamResult> GetFileAsync(ControllerBase controller, string filename, string mimeType)
        {
            ...
            return controller.File(memory, mimeType, filename);
        }
