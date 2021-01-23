    XNamespace ns = "http://tempuri.org/";
    var doc = XDocument.Parse(result);
    var data = doc.Root       // ArrayOfCO_App_Table_CO_VERTRETERFTPLOGIN
                  .Elements() // CO_App_Table_CO_VERTRETERFTPLOGIN
                  .Select(x => new Database.Tabellen.co_vertreterftplogin
                  {
                      id = (string) x.Element(ns + "id"),
                      ...
                  });
