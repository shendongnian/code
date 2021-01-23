        using (XDocument xdoc = XDocument.Load(@"C:\Users\aks\Desktop\sample.xml"))
            {
                var customers = xdoc.Descendants("customer");
                var totalNodes = customers.Count();
                var filledNames = customers.Descendants("name").Where(x => x.Value != string.Empty).Count();
                var filledAges = customers.Descendants("age").Where(x => x.Value != string.Empty).Count();
                var filledGenders = customers.Descendants("gender").Where(x => x.Value != string.Empty).Count();
                var unfilledNames = totalNodes - filledNames;
                var unfilledAges = totalNodes - filledAges;
                var unfilledGenders = totalNodes - filledGenders;
            }
