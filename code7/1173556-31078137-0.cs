    using (XmlReader xmlReader = XmlReader.Create("file.xml"))
    {
        while (xmlReader.Read())
        {
            if (xmlReader.ReadToFollowing("SponsorID"))
            {
                string sponsorId = xmlReader.ReadElementContentAsString();
                // process SponsorID
                Console.WriteLine(sponsorId);
                if (xmlReader.ReadToFollowing("Contract"))
                {
                    do
                    {
                        XmlReader contractSubtree = xmlReader.ReadSubtree();
                        XElement contractElement = XElement.Load(contractSubtree);
                        // process Contract
                        Console.WriteLine(contractElement.Element("ContractID"));
                    } while (xmlReader.ReadToNextSibling("Contract"));
                }
            }
        }
    }
