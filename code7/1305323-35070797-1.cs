    // Split the string into groups using newline as a delimiter.
    string[] groups = str.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    // Use skip and take to trim the first 3 and last 4 elements.
    // Rejoin the remainder back together with empty strings and parse the XElement.
    string xmlString = string.Join(string.Empty, groups.Take(groups.Length - 4).Skip(3));
    XElement xml = XElement.Parse(xmlString);
    // Use Descendants and First to get the first node called 'name' in the XML.
    XElement name = xml.Descendants("name").First();
