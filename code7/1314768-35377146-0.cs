    var newDocument =
            new XDocument(new XElement("Request",
                from query in xlQueryTest
                from baseInfo in query.Baseinfo
                select
                new XElement("BaseInfo",
                    new XElement("MachineDescription", baseInfo.MachineName),
                    new XElement("ServiceTag", baseInfo.ServiceTag),
                    new XElement("ShipDate", baseInfo.WarrantyStart),
                    new XElement("Warranites",
                        from grp in baseInfo.Warranties
                        from warranty in grp
                        select
                        new XElement("Warranty",
                            new XElement("ServiceLevelDescription", warranty.Service),
                            new XElement("ServiceProvider", warranty.Provider),
                            new XElement("StartDate", warranty.StartDate),
                            new XElement("EndDate", warranty.EndDate)
                        )
                    )
                )
            ));
