    Byte[] content = (Byte[])vDr["EmpImage"]
    
    //Option 1
    Image img = new Bitmap(new MemoryStream(content));
    Encoding _Encoding = Encoding.UTF8;
    
    var props = img.PropertyItems;
    string propData;
    foreach (var propertyItem in props)
    {
        propData = _Encoding.GetString(propertyItem.Value);
        Debug.WriteLine("{0}[{1}]", propertyItem.Id, propData);
    }
    
    //option 2 - require reference of PresentationCore and WindowsBase and then using System.Windows.Media.Imaging
    var imgFrame = BitmapFrame.Create(new MemoryStream(content));
    var metadata = imgFrame.Metadata as BitmapMetadata;
    
    //option 3 - require MetadataExtractor Nuget package
    var mr = ImageMetadataReader.ReadMetadata(new MemoryStream(content));
    foreach (var directory in mr)
    {
        foreach (var tag in directory.Tags)
        {
            Debug.WriteLine("{0} - {1} = {2}]", directory.Name, tag.Name, tag.Description);
        }
    }
