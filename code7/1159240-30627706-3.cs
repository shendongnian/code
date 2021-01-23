            var query = from rect in xXmlDoc.XPathSelectElements("//CLabelContainer/Labels/LabelList/CLabel/VehicleLabel/BoundingRect")
                        select new cROI
                        (
                             Int16.Parse(rect.Element("X").Value, NumberFormatInfo.InvariantInfo),
                             Int16.Parse(rect.Element("Y").Value, NumberFormatInfo.InvariantInfo),
                             Int16.Parse(rect.Element("Width").Value, NumberFormatInfo.InvariantInfo),
                             Int16.Parse(rect.Element("Height").Value, NumberFormatInfo.InvariantInfo)
                        );
            var AllBoundingRect = query.ToList();
