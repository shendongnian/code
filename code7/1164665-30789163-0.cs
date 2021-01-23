    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME2 = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = 
                "<XML><HEADER>1.0,770162,20121009133435,3,</HEADER>20121009133435,721,5,1,0,0,0,00:00,00:00,<EVENT>00032134826064957,4627,</EVENT><DRUG>1,1872161156,7,0,10000</DRUG><DOSE>1,0,5000000,0,10000000,0</DOSE><CAREAREA>1 </CAREAREA><ENCOUNTER></ENCOUNTER><ADVISORY>Keep it simple or spell\n" +
                        "tham ALL out. For some reason \n" +
                        "that is not the case\n" +
                        "please press the on button\n" + 
                        "when trying to activate\n" +
                        "device codes also available on\n" +
                    "list</ADVISORY><CAREGIVER></CAREGIVER><PATIENT></PATIENT><LOCATION>20121009133435,00-1d-71-0a-71-80,-66</LOCATION><ROUTE></ROUTE><SITE></SITE><POWER>0,50</POWER></XML>\n" + 
                "<XML><HEADER>2.0,773162,20121009133435,3,</HEADER>20121004133435,761,5,1,0,0,0,00:00,00:00,<EVENT>00032134826064957,4627,</EVENT><DRUG>1,18735166156,7,0,10000</DRUG><DOSE>1,0,5000000,0,10000000,0</DOSE><CAREAREA>1 </CAREAREA><ENCOUNTER></ENCOUNTER><ADVISORY>Keep it simple or spell\n" +
                        "tham ALL out. For some reason\n" + 
                        "that is not the case\n" +
                        "please press the on button\n" + 
                        "when trying to activate\n" +
                       "device codes also available on\n" +
                    "list</ADVISORY><CAREGIVER></CAREGIVER><PATIENT></PATIENT><LOCATION>20121009133435,00-1d-71-0a-71-80,-66</LOCATION><ROUTE></ROUTE><SITE></SITE><POWER>0,50</POWER></XML>\n";
                xmlToCSVfiltered(input, 4267); 
            }
            static public void xmlToCSVfiltered(string p, int e)
            {
                //string all_lines1 = File.ReadAllText(p);
                StringReader reader = new StringReader(p);
                string all_lines1 = reader.ReadToEnd();
                all_lines1 = "<Root>" + all_lines1 + "</Root>";
                XDocument doc_all = XDocument.Parse(all_lines1);
                StreamWriter write_all = new StreamWriter(FILENAME2);
                List<XElement> rows_all = doc_all.Descendants("XML").Where(x => x.Element("EVENT").Value.Split(new char[] {','}).Skip(1).Take(1).FirstOrDefault() == "4627").ToList();
                List<string[]> filtered = new List<string[]>();
                foreach (XElement rowtemp in rows_all)
                {
                    List<string> children_all = new List<string>();
                    foreach (XElement childtemp in rowtemp.Elements())
                    {
                        children_all.Add(Regex.Replace(childtemp.Value, "\\s+", " "));     // <------- Fixed the Bug , Advisories dont span          
                    }
                    string.Join(",", children_all.ToArray());
                    //write_all.WriteLine(string.Join(",", children_all.ToArray()));
                    if (children_all.Contains(e.ToString()))
                    {
                        filtered.Add(children_all.ToArray());
                        write_all.WriteLine(children_all);
                    }
                }
                write_all.Flush();
                write_all.Close();
                foreach (var res in filtered)
                {
                    Console.WriteLine(string.Join(",", res));
                }
            }
        }
    }
    ​
