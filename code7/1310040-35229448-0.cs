    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml1 = 
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                        "<Root>" +
                          "<eveapi version=\"2\">" +
                            "<currentTime>2016-02-05 09:35:05</currentTime>" +
                            "<result>" +
                              "<characterID></characterID>" +
                              "<name></name>" +
                              "<homeStationID>61001046</homeStationID>" +
                              "<homeStationID>61001047</homeStationID>" +
                              "<DoB></DoB>" +
                            "</result>" +
                          "</eveapi>" +
                        "</Root>";
                XDocument doc1 = XDocument.Parse(xml1);
                string[] stationIDs = doc1.Descendants("homeStationID").Select(x => x.Value).ToArray();
                string xml2 =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                      "<eveapi version=\"2\">" +
                        "<currentTime>2016-02-05 08:24:56</currentTime>" +
                        "<result>" +
                          "<rowset name=\"outposts\" key=\"stationID\" columns=\"stationID,stationName,stationTypeID,solarSystemID,corporationID,corporationName,x,y,z\">" +
                            "<row stationID=\"61001046\" stationName=\"W-XY4J X - HAKOHELITO\" stationTypeID=\"21646\" solarSystemID=\"30001105\" corporationID=\"98021158\" corporationName=\"corporation federal agents space\" x=\"394820444160\" y=\"-18220769280\" z=\"-6131542302720\"/>" +
                            "<row stationID=\"61001047\" stationName=\"7MD-S1 XI - Roland's Place\" stationTypeID=\"21645\" solarSystemID=\"30001232\" corporationID=\"98132485\" corporationName=\"Bailiffs\" x=\"-2950319185920\" y=\"-500139909120\" z=\"2101918064640\"/>" +
                            "<row stationID=\"61001048\" stationName=\"E9KD-N IX - RIP Vile Rat\" stationTypeID=\"21645\" solarSystemID=\"30003694\" corporationID=\"418183520\" corporationName=\"EXPCS Corp\" x=\"1474703155200\" y=\"-198735421440\" z=\"450142740480\"/>" +
                           "</rowset>" +
                        "</result>" +
                      "</eveapi>";
                XDocument doc2 = XDocument.Parse(xml2);
                XElement[] stationIDsNodes = stationIDs.Select(x => doc2.Descendants("row").Where(y => y.Attribute("stationID").Value == x)).SelectMany(z => z).ToArray();
            }
        }
    }
