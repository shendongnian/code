    XElement test = xmlAnswers.ToXElement();
    XElement keys = xmlAnswerKey.ToXElement();
    test.Add(keys.Descendants("answer").ToList()); // Add Answers to test
    test.Add(new XElement("finalgrade", "A")); // Add final grade
    // Dialog stuff
    test.Save(savefiledialog1.FileName);
