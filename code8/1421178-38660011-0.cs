    foreach (XElement elemColone in docX.Descendants("Stack"))
    {
        foreach (var sectionOrBook in elemColone.Elements())
        {
            if (sectionOrBook.Name == "SectionHorror")
                CreateSectionHorror(sectionOrBook);
            else if (sectionOrBook.Name == "SectionScience")
                CreateSectionScience(sectionOrBook);
            else if (sectionOrBook.Name == "Book")
                CreateBook(sectionOrBook);
        }
    }
