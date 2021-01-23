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
                    "<eConnect xmlns:dt=\"urn:schemas-microsoft-com:datatypes\">" +
                      "<SOPTransactionType>" +
                        "<eConnectProcessInfo>" +
                          "<ConnectionString>Data Source=DGLSQL1;Initial Catalog=dgl;Persist Security Info=False;Integrated Security=SSPI</ConnectionString>" +
                          "<EConnectProcsRunFirst>True</EConnectProcsRunFirst>" +
                        "</eConnectProcessInfo>" +
                        "<taSopLotAuto_Items>" +
                          "<taSopLotAuto>" +
                            "<SOPTYPE>2</SOPTYPE>" +
                            "<SOPNUMBE>435462</SOPNUMBE>" +
                            "<LNITMSEQ>16384</LNITMSEQ>" +
                            "<ITEMNMBR>7740</ITEMNMBR>" +
                            "<LOCNCODE>18</LOCNCODE>" +
                            "<QUANTITY>65</QUANTITY>" +
                            "<LOTNUMBR>15483D0104X68X</LOTNUMBR>" +
                          "</taSopLotAuto>" +
                        "</taSopLotAuto_Items>" +
                      "</SOPTransactionType>" +
                    "</eConnect>";
                XDocument doc = XDocument.Parse(xml);
                XElement taSopLotAuto = doc.Descendants()
                    .Where(x => x.Name.LocalName == "taSopLotAuto")
                    .FirstOrDefault();
                var results = taSopLotAuto.DescendantsAndSelf().Select(x => new {
                    sopType = (int)x.Element("SOPTYPE"),
                    sopNumbe = (int)x.Element("SOPNUMBE"),
                    lnitmsseg = (int)x.Element("LNITMSEQ"),
                    locncode = (int)x.Element("LOCNCODE"),
                    quantity = (int)x.Element("QUANTITY"),
                    lotnumbr = (string)x.Element("LOTNUMBR")
                }).FirstOrDefault();
            }
        }
    }
