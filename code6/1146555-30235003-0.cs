    var source = "<img src='ftp://c//hafiz hussain//appdata//images//image.bmp' />";
    var elt2 = XElement.Parse(source);
    var imgs = elt2.DescendantsAndSelf("img");
    foreach (var im in imgs)
    {
        var att = im.Attributes().Where(p => p.Name.LocalName.ToLower() == "src");
        if (att != null)
        {
           im.SetAttributeValue("src", string.Empty);
        }
    }
    // Converting back to string to see the result
    var resst = elt2.ToString();
