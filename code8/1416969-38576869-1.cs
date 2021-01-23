    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                StreamReader sReader = new StreamReader(FILENAME);
                sReader.ReadLine();
    
                XmlReader reader = XmlReader.Create(sReader);
                reader.Read();
    
                string ns = reader.NamespaceURI;
                reader.ReadToFollowing("body", ns);
                reader.ReadStartElement("body", ns);
                string name = "";
    
                while (!reader.EOF && (reader.NodeType != XmlNodeType.EndElement))
                {
                    if (reader.Name == "") reader.Read();
                    name = reader.Name;
    
                    if (!reader.EOF && (reader.NodeType != XmlNodeType.EndElement))
                    {
                        XElement node = (XElement)XElement.ReadFrom(reader);
                        switch (node.Name.LocalName)
                        {
                            case "p":
                                string paraId = (string)node.Attributes().Where(x => x.Name.LocalName == "paraId").FirstOrDefault();
                                string textId = (string)node.Attributes().Where(x => x.Name.LocalName == "textId").FirstOrDefault();
                                string rsidR = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidR").FirstOrDefault();
                                string rsidRDefault = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidRDefault").FirstOrDefault();
                                string rsidP = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidP").FirstOrDefault();
    
                                var rS = node.Descendants().Where(x => x.Name.LocalName == "r").Select(x => new {
                                    rsidR = (string)x.Attributes().Where(y => y.Name.LocalName == "rsidR").FirstOrDefault(),
                                    rsidRDefault = (string)x.Attributes().Where(y => y.Name.LocalName == "rsidRDefault").FirstOrDefault(),
                                    t = (string)x.Descendants().Where(y => y.Name.LocalName == "t").FirstOrDefault()
                                }).ToList();
    
                                var bookMarkStart = node.Descendants().Where(x => x.Name.LocalName == "bookmarkStart").Select(x => new
                                {
                                    id = (int)x.Attributes().Where(y => y.Name.LocalName == "id").FirstOrDefault(),
                                    name = (string)x.Attributes().Where(y => y.Name.LocalName == "name").FirstOrDefault()
                                }).FirstOrDefault();
    
                               var bookMarkEnd = node.Descendants().Where(x => x.Name.LocalName == "bookmarkEnd").Select(x => new
                                {
                                    id = (int)x.Attributes().Where(y => y.Name.LocalName == "id").FirstOrDefault(),
                                    name = (string)x.Attributes().Where(y => y.Name.LocalName == "name").FirstOrDefault()
                                }).FirstOrDefault();
    
                                break;
    
                            case "pPr":
                                XElement rFonts = node.Descendants().Where(x => x.Name.LocalName == "rFonts").FirstOrDefault();
                                if (rFonts != null)
                                {
                                    string ascii = (string)rFonts.Attributes().Where(x => x.Name.LocalName == "ascii").FirstOrDefault();
                                    string hAnsi = (string)rFonts.Attributes().Where(x => x.Name.LocalName == "hAnsi").FirstOrDefault();
                                    string cs = (string)rFonts.Attributes().Where(x => x.Name.LocalName == "cs").FirstOrDefault();
    
                                }
                                XElement b = node.Descendants().Where(x => x.Name.LocalName == "b").FirstOrDefault();
                                if (b != null)
                                {
                                    string bVal = (string)b.Attributes().Where(x => x.Name.LocalName == "val").FirstOrDefault();
    
                                }
                                XElement sz = node.Descendants().Where(x => x.Name.LocalName == "sz").FirstOrDefault();
                                if (sz != null)
                                {
                                    int szVal = (int)sz.Attributes().Where(x => x.Name.LocalName == "val").FirstOrDefault();
                                }
                                XElement szCs = node.Descendants().Where(x => x.Name.LocalName == "szCs").FirstOrDefault();
                                if (szCs != null)
                                {
                                    int szCsVal = (int)szCs.Attributes().Where(x => x.Name.LocalName == "val").FirstOrDefault();
                                }
                                break;
    
                            case "r":
                                    string rsidRPr = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidRPr").FirstOrDefault();
                                break;
    
                            case "sectPr" :
                                string sectRsidR = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidR").FirstOrDefault();
                                var pgSz = node.Descendants().Where(x => x.Name.LocalName == "pgSz").Select(x => new
                                {
                                    w = (int)x.Attributes().Where(y => y.Name.LocalName == "w").FirstOrDefault(),
                                    h = (int)x.Attributes().Where(y => y.Name.LocalName == "h").FirstOrDefault()
                                }).FirstOrDefault();
    
                                var pgMar = node.Descendants().Where(x => x.Name.LocalName == "pgMar").Select(x => new
                                {
                                    top = (int)x.Attributes().Where(y => y.Name.LocalName == "top").FirstOrDefault(),
                                    right = (int)x.Attributes().Where(y => y.Name.LocalName == "right").FirstOrDefault(),
                                    bottom = (int)x.Attributes().Where(y => y.Name.LocalName == "bottom").FirstOrDefault(),
                                    left = (int)x.Attributes().Where(y => y.Name.LocalName == "left").FirstOrDefault(),
                                    header = (int)x.Attributes().Where(y => y.Name.LocalName == "header").FirstOrDefault(),
                                    footer = (int)x.Attributes().Where(y => y.Name.LocalName == "footer").FirstOrDefault(),
                                    gutter = (int)x.Attributes().Where(y => y.Name.LocalName == "gutter").FirstOrDefault()
                                }).FirstOrDefault();
    
                                var cols = node.Descendants().Where(x => x.Name.LocalName == "cols").Select(x => new
                                {
                                    space = (int)x.Attributes().Where(y => y.Name.LocalName == "space").FirstOrDefault()
                                }).FirstOrDefault();
    
                                var docGrid = node.Descendants().Where(x => x.Name.LocalName == "docGrid").Select(x => new
                                {
                                    linePitch = (int)x.Attributes().Where(y => y.Name.LocalName == "linePitch").FirstOrDefault()
                                }).FirstOrDefault();
    
                                break;
    
                            case "tr":
                                string trRsidR = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidR").FirstOrDefault();
                                string trParaId = (string)node.Attributes().Where(x => x.Name.LocalName == "paraId").FirstOrDefault();
                                string trTextId = (string)node.Attributes().Where(x => x.Name.LocalName == "textId").FirstOrDefault();
                                string tRrsidTr = (string)node.Attributes().Where(x => x.Name.LocalName == "rsidTr").FirstOrDefault();
                                break;
    
                            default:
                                //should not get here
                                break;
                        }
                    }
                }
            }
        }
    }
