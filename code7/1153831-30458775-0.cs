    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Section> sections = new List<Section>();
                string input =
                   "START-OF-DATA\n" +
                   "#100846105\n" +
                   "START SECURITY|US912810DZ85|CBBT|\n" +
                   "## in: 20150430_14:59:00 to 20150430_15:00:00 [13 (New York-DST)]\n" +
                   "## out:20150430_14:59:00 to 20150430_15:00:00 [13 (New York-DST)]\n" +
                   "04/30|15:00:00|B|118.640625||| |A|118.703125||| ||\n" +
                   "04/30|14:59:54|B|118.6328125||| |A|118.6953125||| ||\n" +
                   "04/30|14:59:52|B|118.6328125||| |A|118.6953125||| ||\n" +
                   "04/30|14:59:23|B|118.6328125||| |A|118.6953125||| ||\n" +
                   "04/30|14:59:20|B|118.6328125||| |A|118.6953125||| ||\n" +
                   "END SECURITY|US912810DZ85|0|\n" +
                   "#100846111\n" +
                   "START SECURITY|US912810EA26|CBBT|\n" +
                   "## in: 20150430_14:59:00 to 20150430_15:00:00 [13 (New York-DST)]\n" +
                   "## out:20150430_14:59:00 to 20150430_15:00:00 [13 (New York-DST)]\n" +
                   "04/30|15:00:00|B|124.75||| |A|124.828125||| ||\n" +
                   "04/30|14:59:55|B|124.75||| |A|124.8203125||| ||\n" +
                   "04/30|14:59:53|B|124.7421875||| |A|124.8203125||| ||\n" +
                   "04/30|14:59:45|B|124.7421875||| |A|124.8125||| ||\n" +
                   "04/30|14:59:43|B|124.7421875||| |A|124.828125||| ||\n" +
                   "04/30|14:59:27|B|124.7421875||| |A|124.8125||| ||\n" +
                   "04/30|14:59:24|B|124.7421875||| |A|124.828125||| ||\n" +
                   "04/30|14:59:22|B|124.7421875||| |A|124.8125||| ||\n" +
                   "04/30|14:59:20|B|124.7421875||| |A|124.828125||| ||\n" +
                   "04/30|14:59:13|B|124.7421875||| |A|124.8125||| ||\n" +
                   "END SECURITY|US912810EA26|0|\n" +
                   "END-OF-DATA\n";
                StringReader reader = new StringReader(input);
                string inputLine = "";
                Section newSection = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.StartsWith("#"))
                    {
                        if (inputLine.Contains("in:")) continue;
                        if (inputLine.Contains("out:")) continue;
                        newSection = new Section();
                        sections.Add(newSection);
                        newSection.iD = inputLine.Substring(1);
                        newSection.data = new List<string>();
                    }
                    else
                    {
                        if (inputLine.Substring(0, 3) == "END") continue;
                        if (inputLine.Substring(0, 5) == "START") continue;
                        newSection.data.Add(inputLine);
                    }
                }
            }
            public class Section
            {
                public string iD { get; set; }
                public List<string> data { get; set; }
            }
        }
        
    }
