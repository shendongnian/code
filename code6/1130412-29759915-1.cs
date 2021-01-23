    StorageFile file = await  ApplicationData.Current.LocalFolder.GetFileAsync("data.xml");
    XDocument doc = XDocument.Load(file.Path);
    XElement newQuestion = new XElement("Question",
           new XElement("time", tak.Time),
           new XElement("text", tak.Text)
            ).SetAttributeValue("Date", tak.Date);
    doc.Root.Add(newQuestion);
    await FileIO.WriteTextAsync(file, doc.Root.ToString());
