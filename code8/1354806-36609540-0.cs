    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<queries>" +
                      "<selectparent table=\"Associates\">\"SELECT * FROM @table\"</selectparent>" +
                      "<selectchild table=\"VehicleContract\">\"SELECT * FROM @table\"</selectchild>" +
                      "<addchild table=\"VehicleContract\" read=\"contractId, regNr, assoc_id, percentage, vehicleType, trailerNr\">\"INSERT into @table (contractId, regNr, assoc_id, percentage, vehicleType, trailerNr) VALUES (@id, @reg, @assort, @perc, @type, @trailer)\"</addchild>" +
                      "<updatechild table=\"VehicleContract\" read=\"contractId, regNr, assoc_id, percentage, vehicleType, trailerNr\">\"UPDATE @table SET regNr=@reg, assoc_id=@assort, percentage=@perc, vehicleType=@type, trailerNr=@trailer WHERE contractId=@id\"</updatechild>" +
                      "<removechild table=\"VehicleContract\" read=\"id\">\"DELETE from @table WHERE contractId=@id\"</removechild>" +
                    "</queries>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Elements("queries").Select(x => new
                {
                    selectParent = x.Elements("selectparent").Select(y => new
                    {
                        table = (string)y.Attribute("table"),
                        value = y.Value
                    }).FirstOrDefault(),
                    selectChild = x.Elements("selectchild").Select(y => new
                    {
                        table = (string)y.Attribute("table"),
                        value = y.Value
                    }).FirstOrDefault(),
                    addChild = x.Elements("addchild").Select(y => new
                    {
                        table = (string)y.Attribute("table"),
                        read = (string)y.Attribute("read"),
                        value = y.Value
                    }).FirstOrDefault(),
                    updateChild = x.Elements("updatechild").Select(y => new
                    {
                        table = (string)y.Attribute("table"),
                        read = (string)y.Attribute("read"),
                        value = y.Value
                    }).FirstOrDefault(),
                    removeChild = x.Elements("removechild").Select(y => new
                    {
                        table = (string)y.Attribute("table"),
                        read = (string)y.Attribute("read"),
                        value = y.Value
                    }).FirstOrDefault(),
                }).FirstOrDefault();
            }
        }
    }
