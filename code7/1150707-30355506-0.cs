    private static Person ReadPerson(XmlReader rdr)
    {
      var person = new Person();
      using(rdr)
        while(rdr.Read())
          if(rdr.IsStartElement())
            switch(rdr.Name)
            {
              case "Name":
                person.Name = rdr.ReadElementContentAsString();
                break;
              case "Email":
                person.Email =  rdr.ReadElementContentAsString();
                break;
              case "StreetAddress":
                person.Address = rdr.ReadElementContentAsString();
                break;
              case "Notes":
                person.Notes = rdr.ReadElementContentAsString();
                break;
              case "DateOfBirth":
                person.DateOfBirth = DateTime.Parse(rdr.ReadElementContentAsString(), CultureInfo.GetCultureInfo("en-US"));
                break;
            }
      return person;
    }
