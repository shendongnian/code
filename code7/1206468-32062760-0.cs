<!-- language: lang-css --
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
                string input =
                    "<Vib>" +
                       "<SystemReports>" +
                      "<ReportUrl path=\"http://lenovo-pc/Report\" ReportFolder=\"/AllSSRSReports\" ExportFilePath=\"E:\\Vib\\\" />" +
                      "<ImageFolder path=\"D:\\Images\" />" +
                      "<MailingLabels AvailableBarcode=\"Code39,Code93,CodeQR\">" +
                        "<MailingLabel Type=\"L7654\" Width=\"45.7\" Height=\"25.4\" HorizontalGapWidth=\"2.6\" VerticalGapHeight=\"0\" PageMarginTop=\"21.4\" PageMarginBottom=\"21.4\" PageMarginLeft=\"9.7\" PageMarginRight=\"9.7\" PageSize=\"A4\" LabelsPerRow=\"4\" LabelRowsPerPage=\"10\" />" +
                        "<MailingLabel Type=\"L7656\" Width=\"46\" Height=\"11.1\" HorizontalGapWidth=\"4.7\" VerticalGapHeight=\"1.6\" PageMarginTop=\"15.9\" PageMarginBottom=\"15.9\" PageMarginLeft=\"6\" PageMarginRight=\"6\" PageSize=\"A4\" LabelsPerRow=\"4\" LabelRowsPerPage=\"21\" />" +
                        "<MailingLabel Type=\"L7160\" Width=\"63.5\" Height=\"38.1\" HorizontalGapWidth=\"2.5\" VerticalGapHeight=\"0\" PageMarginTop=\"15.1\" PageMarginBottom=\"15.1\" PageMarginLeft=\"7.2\" PageMarginRight=\"7.2\" PageSize=\"A4\" LabelsPerRow=\"3\" LabelRowsPerPage=\"7\" />" +
                      "</MailingLabels>" +
                    "</SystemReports>" +
                    "</Vib>";
                XDocument xdo = XDocument.Parse(input);
                var dictionary = (from t in xdo.Descendants("MailingLabel")
                                  select new
                                  {
                                      Type = (string)t.Attribute("Type"),
                                      Width = (string)t.Attribute("Width"),
                                      HorizontalGapWidth = (string)t.Attribute("HorizontalGapWidth"),
                                      VerticalGapHeight = (string)t.Attribute("VerticalGapHeight"),
                                      PageMarginTop = (string)t.Attribute("PageMarginTop"),
                                      PageMarginBottom = (string)t.Attribute("PageMarginBottom"),
                                      PageMarginLeft = (string)t.Attribute("PageMarginLeft"),
                                      PageMarginRight = (string)t.Attribute("PageMarginRight"),
                                      PageSize = (string)t.Attribute("PageSize"),
                                      LabelsPerRow = (string)t.Attribute("LabelsPerRow"),
                                      LabelRowsPerPage = (string)t.Attribute("LabelRowsPerPage")
                                  }).GroupBy(x => x.Type, y => y)
                                  .ToDictionary(x => x.Key, y => y.ToList());
               
            }
        }
    }
    ​
