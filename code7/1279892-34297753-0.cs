    myList.AddRange(oGal.AddressEntries.Cast<Outlook.AddressEntry>()
        .Where(i=>i.Name.Contains("#"))
        .Select(
           x => new ListDetails
                 {
                    Id = val,
                    Name = x.Name
                 }).Take(400));
