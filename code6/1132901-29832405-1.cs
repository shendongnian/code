    public List<PhoneNumber> PhoneNumberFromXML(XDocument xd)
    {
        List<PhoneNumber> lpn = new List<PhoneNumber>();
        foreach (XElement el in xd.Root.Descendants("Speed2G").First().Elements())
        {
            PhoneNumber pn = new PhoneNumber();
            //... logic to parse the individual elements into your class
            lpn.Add(pn);
        }
        return lpn;
    }
