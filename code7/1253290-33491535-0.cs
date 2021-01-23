    XElement test = xmlAnswers.ToXElement();
    XElement keys = xmlAnswerKey.ToXElement();
    
    test.Descendants("answer")
        .ToList()
        .ForEach(a => a.Add(new XElement(keys))); // Add clone of keys to each answer
    // Dialog stuff
    test.Save(savefiledialog1.FileName);
