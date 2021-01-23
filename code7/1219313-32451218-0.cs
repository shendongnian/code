    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    private List<ByteArrayContent> GetFileByteArrayContent(HashSet<string> files)
    {
        List<ByteArrayContent> list = new List<ByteArrayContent>();
        foreach (var file in files)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes(file));
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = Path.GetFileName(file)
            };
            list.Add(fileContent);
        }
        return list;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    private List<ByteArrayContent> GetFormDataByteArrayContent(NameValueCollection collection)
    {
        List<ByteArrayContent> list = new List<ByteArrayContent>();
        foreach (var key in collection.AllKeys)
        {
            var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
            dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                Name = key
            };
            list.Add(dataContent);
        }
        return list;
    }
