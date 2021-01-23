    async private void RenderPages(String pdfUrl)
    {
        try
        {
            HttpClient client = new HttpClient();
            var responseStream = await client.GetInputStreamAsync(new Uri(pdfUrl));
            InMemoryRandomAccessStream inMemoryStream = new InMemoryRandomAccessStream();
            using (responseStream)
            {
                await responseStream.AsStreamForRead().CopyToAsync(inMemoryStream.AsStreamForWrite());
            }
            var pdf = await PdfDocument.LoadFromStreamAsync(inMemoryStream);
            if (pdf != null && pdf.PageCount > 0)
            {
                AddPages(pdf);
            }
        }
        catch (Exception e)
        {
            throw new CustomException("An exception has been thrown while rendering PDF document pages", e);
        }
    }
    async public void AddPages(PdfDocument pdfDocument)
    {
        PagesStackPanel.Children.Clear();
        if (pdfDocument == null || pdfDocument.PageCount == 0)
        {
            throw new ArgumentException("Invalid PdfDocument object");
        }
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        StorageFolder rootFolder = await StorageFolder.GetFolderFromPathAsync(path);
        var storageItemToDelete = await rootFolder.TryGetItemAsync(Constants.LOCAL_TEMP_PNG_FOLDER);
        if (storageItemToDelete != null)
        {
            await storageItemToDelete.DeleteAsync();
        }
        StorageFolder tempFolder = await rootFolder.CreateFolderAsync(Constants.LOCAL_TEMP_PNG_FOLDER, CreationCollisionOption.OpenIfExists);
        for (uint i = 0; i < pdfDocument.PageCount; i++)
        {
            logger.Info("Adding PDF page nr. " + i);
            try
            {
                await AppendPage(pdfDocument.GetPage(i), tempFolder);
            }
            catch (Exception e)
            {
                logger.Error("Error while trying to append a page: ", e);
                throw new CustomException("Error while trying to append a page: ", e);
            }
        }
    }
