    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<Lead>" +
                        "<ID>1189226</ID>" +
                        "<Client>" +
                            "<ID>8445254</ID>" +
                            "<Name>City of Lincoln Council</Name>" +
                        "</Client>" +
                        "<Contact>" +
                            "<ID>5747449</ID>" +
                            "<Name>Fred Bloggs</Name>" +
                        "</Contact>" +
                        "<Owner>" +
                            "<ID>36612</ID>" +
                            "<Name>Joe Bloggs</Name>" +
                        "</Owner>" +
                        "<CustomFields>" +
                            "<CustomField>" +
                              "<ID>31961</ID>" +
                              "<Name>Scotsm_A_n_Authority_Good</Name>" +
                              "<Boolean>true</Boolean>" +
                            "</CustomField>" +
                            "<CustomField>" +
                              "<ID>31963</ID>" +
                              "<Name>Scotsma_N_Need Not Want</Name>" +
                              "<Boolean>false</Boolean>" +
                            "</CustomField>" +
                         "</CustomFields>" +
                     "</Lead>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("CustomField").Select(x => new
                {
                    id = (int)x.Element("ID"),
                    name = (string)x.Element("Name"),
                    boolean = (Boolean)x.Element("Boolean")
                }).ToList();
            }
        }
     
    }
