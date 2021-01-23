            using (var sr = new StreamReader(xml))
            using (var xtr = new XmlTextReader(sr))
            {
                xtr.EntityHandling = EntityHandling.ExpandCharEntities; // Expands character entities and returns general entities as System.Xml.XmlNodeType.EntityReference
                var oldDoc = new XmlDocument();
                oldDoc.Load(xtr);
                Debug.WriteLine(oldDoc.DocumentElement.OuterXml); // Outputs <sgml>&question;&signature;</sgml>
                Debug.Assert(oldDoc.DocumentElement.OuterXml.Contains("&question;")); // Verify that the entity references are still there - no assert
                Debug.Assert(oldDoc.DocumentElement.OuterXml.Contains("&signature;")); // Verify that the entity references are still there - no assert
            }
