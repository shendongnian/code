            class Photo
            {
                DateTime date  {get; set;}
                Int32 staffno {get; set;}
                string file {get; set;}
                string crimeref {get; set;}
            };
     // :
     var bikes = from b in xml.Descendants("Photo")
            select new Photo
            {
                date = (DateTime)b.Element("Date"),
                staffno = (Int32)b.Element("StaffNo"),
                file = (string)b.Element("File"),
                crimeref = (string)b.Element("CrimeRef")
            };
