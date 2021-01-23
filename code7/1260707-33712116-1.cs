     var result = xdoc.Root.Elements("data")
                      .Select(x =>
                           {
                               var ContactRow = x.Elements("data")
                                .FirstOrDefault(z => (string)z.Attribute("name") == "CONTACT");
                               var PHONE1Row = x.Elements("data")
                                .FirstOrDefault(z => (string)z.Attribute("name") == "PHONE1");
                               return new
                                      {
                                         Contact = (string)ContactRow,
                                         Phone1 = (string)PHONE1Row
                                      };
                           });
