    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Topic> topics = new List<Topic>();
                XmlReader reader = XmlReader.Create(FILENAME);
                Topic topic = null;
                while (!reader.EOF)
                {
                    if(reader.Name != "paragraph")
                    {
                        reader.ReadToFollowing("paragraph");
                    }
                    if (!reader.EOF)
                    {
                        XElement paragraph = (XElement)XElement.ReadFrom(reader);
                        foreach(XElement subPara in paragraph.Elements())
                        {
                            switch(subPara.Name.LocalName)
                            {
                                case "text" :
                                    topic = new Topic();
                                    topics.Add(topic);
                                    topic.title = (string)subPara;
                                    break;
                                case "page":
                                    topic.page = (int?)subPara;
                                    break;
                                default:
                                    KeyValuePair<string, string> newPara = new KeyValuePair<string, string>(
                                        subPara.Name.LocalName,
                                        (string)subPara
                                    );
                                    topic.paragraphs.Add(newPara);
                                    break;
                            }
                        }
                    }
                }
                
            }
        }
        class Topic
        {
            public string title { get; set; }
            public int? page { get; set; }
            public List<KeyValuePair<string, string>> paragraphs { get; set; }
            public Topic()
            {
                paragraphs = new List<KeyValuePair<string, string>>();
            }
        }
     }
