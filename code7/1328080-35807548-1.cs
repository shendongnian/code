            IEnumerable<XElement> inStudentsElements = 
                sourceXmlDoc.Root.Elements("Classes").Descendants("Class")
                              .Descendants("Students").Descendants("Student");
            XmlNodeList outStudentsElements = targetXmlDoc.GetElementsByTagName("Students")[0].ChildNodes;
            var inStudentsList = inStudentsElements.Select(i => 
                new { Id = i.Elements().First().Value, 
                    Name = i.Elements().Last().Value });
            var outStudentsList = new List<object>();
            for (int i = 0; i < outStudentsElements.Count; i++)
            {
                outStudentsList.Add(new { Id = outStudentsElements[i].ChildNodes[0].InnerText, 
                                        Name = outStudentsElements[i].ChildNodes[1].InnerText });
            }
            if (inStudentsList.SequenceEqual(outStudentsList))
            {
                return;
            }
            else
            {
                var elementsToAdd = inStudentsList.Except(outStudentsList);
                foreach (var element in elementsToAdd)
                {
                    // create xmlNode with element properties, add element to xml
                }
            }
