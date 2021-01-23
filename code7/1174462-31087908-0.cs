    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = 
                    "<owl:ObjectProperty rdf:about=\"http://www.semanticweb.org/rukhsana/ontologies/2015/5/untitled-ontology-21#ہیز_پرائس\">" +
                          "<rdfs:range rdf:resource=\"http://www.semanticweb.org/rukhsana/ontologies/2015/5/untitled-ontology-21#پرائس\"/>" +    
                       "<owl:inverseOf rdf:resource=\"http://www.semanticweb.org/rukhsana/ontologies/2015/5/untitled-ontology-21#پرائس_فار\"/>" +
                          "<rdfs:domain rdf:resource=\"http://www.semanticweb.org/rukhsana/ontologies/2015/5/untitled-ontology-21#کار_ایڈ\"/>" +
                    "</owl:ObjectProperty>";
                string pattern = ":(?'tag'[^=]+)=\"(?'url'[^#]+)#(?'arabic'[^\"]+)";
                Regex expr = new Regex(pattern, RegexOptions.Singleline);
                MatchCollection matches = expr.Matches(input);
                foreach(Match match in matches)
                {
                    Console.WriteLine("tag : {0}; url : {1}; arabic : {2}", match.Groups["tag"].Value, match.Groups["url"].Value, match.Groups["arabic"].Value);
                }
                Console.ReadLine();
            }
        }
    }
    ​
