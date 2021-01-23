    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication28
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<Connection ConnectionID=\"106359\" From_PhraseID=\"1\" To_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" />" +
                    "<Connection ConnectionID=\"106360\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"tg0if2-jc8-k6i-spg-2tof46ftr_nl\" />" +
                    "<Connection ConnectionID=\"106361\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"4trq50-2h0-kqc-9ku-bm8f4cte7_nl\" />" +
                    "<Connection ConnectionID=\"106362\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"1fpspg-tmq-7ln-a9b-3mr3962ca_nl\" />" +
                    "<Connection ConnectionID=\"106358\" From_PhraseID=\"tg0if2-jc8-k6i-spg-2tof46ftr_nl\" To_PhraseID=\"jmrgi1-dst-kt6-roo-lrahuk6tj_nl\" />" +
                    "<Connection ConnectionID=\"106373\" From_PhraseID=\"4trq50-2h0-kqc-9ku-bm8f4cte7_nl\" To_PhraseID=\"97bngg-ggb-k8l-ggf-qnre46ckq_nl\" />" +
                    "<Connection ConnectionID=\"106376\" From_PhraseID=\"1fpspg-tmq-7ln-a9b-3mr3962ca_nl\" To_PhraseID=\"bqgccm-55n-iur-061-27obhegve_nl\" />";
                input = "<Root>" + input + "</Root>";
                StringReader reader = new StringReader(input);
                XDocument doc = XDocument.Load(reader);
                int value = 1;
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (XElement connection in doc.Root.Elements("Connection"))
                {
                    string fromAttr = connection.Attribute("From_PhraseID").Value;
                    if (!dict.ContainsKey(fromAttr))
                    {
                        dict.Add(fromAttr, value++);
                    }
                    string toAttr = connection.Attribute("To_PhraseID").Value;
                    if (!dict.ContainsKey(toAttr))
                    {
                        dict.Add(toAttr, value++);
                    }
                }
                foreach (XElement connection in doc.Root.Elements("Connection"))
                {
                    string fromAttr = connection.Attribute("From_PhraseID").Value;
                    connection.Attribute("From_PhraseID").Value = dict[fromAttr].ToString();
                    string toAttr = connection.Attribute("To_PhraseID").Value;
                    connection.Attribute("To_PhraseID").Value = dict[toAttr].ToString();
                }
            }
        }
    }
