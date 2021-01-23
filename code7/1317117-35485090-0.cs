    var elements = xdoc.Element("FOLDERS");
                if (elements == null)
                {
                    throw new KeyNotFoundException();
                }
                var data = elements
                    .Elements("FOLDER")
                    .Where(xml => xml
                                    .Elements("TABSHEET")
                                    .Elements("DOCUMENT")
                                    .Select(x => x.Attribute("FileName").Value)
                                    .ToList()
                                    .Contains(file.FileName)
                    )
                    .Select(xml => xml
                                    .Elements("TABSHEET")
                                    .Elements("INDEXFIELD")
                                    .Where(x =>
                                        x.Attribute("Name").Value == "Date" ||
                                        x.Attribute("Name").Value == "Note" 
                                        )
                                    .Select(x => new string[] { (string)x.Attribute("Name"), (string)x.Value }))
                    .ToList();
                if (data.Count != 1)
                {
                    file.Upload = false;
                    continue;
                }
                var dataDictionary = data[0].ToDictionary(item => item[0],
                    item => item[1]);
                file.Date = !dataDictionary.ContainsKey("Date") || string.IsNullOrWhiteSpace(dataDictionary["Date"]) ? new DateTime() : DateTime.Parse(dataDictionary["Date"]);
