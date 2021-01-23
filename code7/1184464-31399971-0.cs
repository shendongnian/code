    var xDocument = XDocument.Parse("yourXmlString");
            XNamespace ns = xDocument.Root.GetDefaultNamespace();
            var result = (from e in xDocument
                              .Descendants(ns + "ListNode").Descendants(ns + "Children")
                              .Descendants(ns + "ListNode").Descendants(ns + "Children")
                              .Descendants(ns + "ListNode").Descendants(ns + "Children")
                              .Descendants(ns + "ListNode")
                               select e.Element(ns + "Name").Value).ToList();
