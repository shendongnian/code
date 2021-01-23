      var document = XDocument.Load(url);
            var root = document.Root;
            if (root == null)
                return;
            var ns = root.GetDefaultNamespace();
            var mainNode = document.Element(ns + "prices");
            if (mainNode == null)
            return;
                var priceNode = mainNode.Elements(ns + "price").FirstOrDefault().Elements();
                var lastEntry = mainNode.Elements(ns + "price").FirstOrDefault().Elements().Last().Elements().Last().Elements();
                foreach (var element in lastEntry.Where(element => element.Name.LocalName == "pricetotalinclvat"))
                {
                    plusPrice = element.Value;
                }
                foreach (var element in priceNode.Where(xElement => xElement.Name.LocalName == "price"))
                {
                    price = element.Value;
                }
