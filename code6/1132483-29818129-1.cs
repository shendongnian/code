    private void RenderPdf(string filePath)
    {
        if (!string.IsNullOrWhiteSpace(filePath))
        {
            webBrowser1.Navigate(@filePath);
        }
    }
