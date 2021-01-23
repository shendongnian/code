    private async Task<WriteableBitmap> InvertPageAsync()
    {
        using (var stream = new InMemoryRandomAccessStream())
        {
            await _page.RenderToStreamAsync(stream, _ro);
            // Use WriteableBitmapEx's FromStream
            WriteableBitmap newWb = await wb.FromStream(stream);
            
            return newWb.Invert(); // ERROR IN HERE 
        }
    }
 
    async Task UpdatePdf()
    {
        // Load the document, page, etc. and PreparePageAsync
        // ...
        // ...
        // Invert the page and show it in pageImage
        pageImage.Source = await InvertPageAsync();
    }
