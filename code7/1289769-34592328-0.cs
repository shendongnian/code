    var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///thedata.txt"));
    using (var inputStream = await file.OpenReadAsync())
    using (var classicStream = inputStream.AsStreamForRead())
    using (var streamReader = new StreamReader(classicStream))
    {
        while (streamReader.Peek() >= 0)
        {
            Debug.WriteLine(string.Format("the line is {0}", streamReader.ReadLine()));
        }
    }
