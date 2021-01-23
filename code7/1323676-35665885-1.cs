    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Dictionary<string, string>> subjects = new List<Dictionary<string, string>>();
                string xml =
                    "<message code=\"L1\" />\n" +
                    "<message code=\"D1\" />\n" +
                    "<message code=\"A1\">NAME: JON              ID: 99017   CODE: 111222333    TYPE: ST</message>\n" +
                    "<message code=\"A2\">NTC:           RISK:               START: 09/01/2015     STATUS: ACTIVE</message>\n" +
                    "<message code=\"CD\">STATE: MS     LAST CANCEL REASON:</message>\n" +
                    "<message code=\"A4\">A, TIM                   (PRIMARY)      OS      09/01/2015    09/01/2016</message>\n" +
                    "<message code=\"D1\" />\n" +
                    "<message code=\"A1\">NAME: Tim              ID: 99017   CODE: 111222333    TYPE: ST</message>\n" +
                    "<message code=\"A2\">NTC:           RISK:               START: 09/01/2015     STATUS: EXPIRED</message>\n" +
                    "<message code=\"CD\">STATE: MS     LAST CANCEL REASON:</message>\n" +
                    "<message code=\"A4\">A, TIM                   (PRIMARY)      OS      09/01/2014    09/01/2015</message>\n" +
                    "<message code=\"D1\" />\n";
                string pattern1 = "<message code=\"(?'code'[^\"]*)\"(>(?'innertext'[^<]*))?";
                string pattern2 = @"((?'name'[^:]*):\s?(?'value'[\w0-9/\<\>]*)?)";
                StringReader reader = new StringReader(xml);
                string inputLine = "";
                Dictionary<string, string> subject = null;
                while((inputLine = reader.ReadLine()) != null)
                {
                    Match match1 = Regex.Match(inputLine, pattern1);
                    string code = match1.Groups["code"].Value;
                    string innertext = match1.Groups["innertext"].Value;
                    if (code == "D1")
                    {
                        subject = new Dictionary<string, string>();
                        subjects.Add(subject);
                    }
                    else
                    {
                        if (innertext.Length > 0)
                        {
                            MatchCollection matches = Regex.Matches(innertext, pattern2);
                            foreach (Match match2 in matches)
                            {
                                string name = match2.Groups["name"].Value.Trim();
                                string value = match2.Groups["value"].Value.Trim();
                                subject.Add(name, value);
                            }
                        }
                    }
                }
            }
        }
    }
