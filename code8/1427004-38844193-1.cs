    XElement rootImg = XElement.Parse(xml string variable);
    
    IEnumerable<XElement> img =
        from el in rootImg.Descendants("ImageObject").ToList()
        where (string)el.Attribute("Format") != ""
        select el;
    
    
    
    foreach (XElement el in img)
    {
        var fileRef = el.Attribute("FileRef");
        el.Name = "img";
        el.RemoveAttributes();
        el.SetAttributeValue("src", fileRef.Value);
    }
