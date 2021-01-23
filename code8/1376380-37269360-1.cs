        if(!xmltag1.Element("name").Value.Equals(xmltag.Descendants(subsection).LastOrDefault().Element("name").Value))
        {
            xmltag1.Element("percentage").Value = remainingallocatedpercentage;
        }
        else
        {
            xmltag1.Element("percentage").Value = remainingallocatedpercentage + 1;
        }
