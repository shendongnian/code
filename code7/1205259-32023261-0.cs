    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                        "<resrourceInfo>" +
                            "<month name=\"jan\">" +
                              "<r>" +
                                 "<rqstType>1</rqstType>" +
                                 "<rsrceName>2</rsrceName>" +
                                 "<dateRqstd>3</dateRqstd>" +
                              "</r>" +
                              "<r>" +
                                 "<rqstType>4</rqstType>" +
                                 "<rsrceName>5</rsrceName>" +
                                 "<dateRqstd>6</dateRqstd>" +
                              "</r>" +
                            "</month>" +
                            "<month name=\"feb\">" +
                              "<r>" +
                                 "<rqstType>7</rqstType>" +
                                 "<rsrceName>8</rsrceName>" +
                                 "<dateRqstd>9</dateRqstd>" +
                              "</r>" +
                              "<r>" +
                                 "<rqstType>10</rqstType>" +
                                 "<rsrceName>11</rsrceName>" +
                                 "<dateRqstd>12</dateRqstd>" +
                              "</r>" +
                            "</month>" +
                        "</resrourceInfo>";
                XDocument doc = XDocument.Parse(input);
                DataSet ds = new DataSet();
                foreach (XElement month in doc.Descendants("month"))
                {
                    DataTable dt = ds.Tables.Add(month.Attribute("name").Value);
                    foreach (XElement row in month.Elements("r"))
                    {
                        if (dt.Rows.Count < 1)
                        {
                            foreach (XElement col in row.Elements())
                            {
                                dt.Columns.Add(col.Name.ToString(), typeof(int));
                            }
                        }
                        DataRow newRow = dt.Rows.Add();
                        foreach (XElement col in row.Elements())
                        {
                            newRow[col.Name.ToString()] = col.Value;
                        }
                    }
                }
            }
        }
    }
    ​
