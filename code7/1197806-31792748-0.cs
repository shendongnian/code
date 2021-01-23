    XElement element =
                new XElement("Root",
                    (from bene in xmlDataSet
                        select new XElement("Item",
                                new XElement("Id", bene.Id),
                                new XElement("ProcessedDate", bene.ProcessedDate),
                                new XElement("FileName", bene.FileName),
                                new XElement("LineCountFile", bene.LineCountFile),
                                new XElement("LineCountHits", bene.LineCountHits),
                                new XElement("Line", bene.SearchLine),
                            new XElement("Entity",
                                    new XElement("Names",
                                    from name in bene.Entity.Names
                                    select new XElement("name", name))))
                                )
                        );
