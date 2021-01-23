    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string XML = 
                    "<Decide Name=\"MemoryCheck\" CommonUnit=\"MB\">" +
                       "<Decision CellColor=\"Red\"    Status=\"Critical\" Exp=\"&lt;=100\" />" +
                       "<Decision CellColor=\"Yellow\" Status=\"Warning\"  Exp=\"&lt;=200 &amp; &gt;100\"/>" +
                       "<Decision CellColor=\"Green\"  Status=\"OK\"       Exp=\"&gt;200\" />" +
                    "</Decide>";
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XML);
                XmlNodeList  memoryCheck = doc.GetElementsByTagName("Decision");
                foreach(XmlNode decision in memoryCheck)
                {
                    Decision newDecision = new Decision();
                    Decision.decisions.Add(newDecision);
                    newDecision.Cellcolor = decision.Attributes.GetNamedItem("CellColor").Value;
                    newDecision.status = decision.Attributes.GetNamedItem("Status").Value;
                    newDecision.low = 0;
                    newDecision.high = null;
                    string exps = decision.Attributes.GetNamedItem("Exp").Value;
                    string[] expsArray = exps.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string exp in expsArray)
                    {
                        if(exp.StartsWith("<="))
                        {
                                newDecision.high = int.Parse(exp.Substring(exp.IndexOf("=") + 1));
                        }
                        if(exp.StartsWith(">"))
                        {
                                newDecision.low = int.Parse(exp.Substring(exp.IndexOf(">") + 1));
                        }
                    }
                }
                Decision result =  Decision.GetBySize(212);
            }
        }
        public class Decision
        {
            public static List<Decision> decisions = new List<Decision>();
            public string Cellcolor { get; set; }
            public string status { get; set; }
            public int? low { get; set; }
            public int? high {get; set;}
            public static Decision GetBySize(int memory)
            {
                Decision newDecision = null;
                foreach(Decision decision in decisions)
                {
                    if (memory >= decision.low)
                    {
                        if (decision.high == null)
                        {
                            newDecision = decision;
                            break;
                        }
                        else
                        {
                            if (memory <= decision.high)
                            {
                                newDecision = decision;
                                break;
                            }
                        }
                    }
                }
                return newDecision;
            }
        }
        
    }
