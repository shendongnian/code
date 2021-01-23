    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml;
    namespace DefinitionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Definition> definitions = new List<Definition>();
                // The starting point after your web service call.
                string responseFromServer = EmulateWebService();
                // Load the string into this object in order to parse the xml.
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);
                XmlNode root = doc.DocumentElement.ParentNode;
                XmlNodeList elemList = doc.GetElementsByTagName("WordDefinition");
                for (int i = 0; i < elemList.Count; i++)
                {
                    XmlNode def = elemList[i];
                    // We only want WordDefinition elements that have just one child which is the content we need.
                    // Any WordDefinition that has zero children or more than one child is either empty or a parent element.
                    if (def.ChildNodes.Count == 1)
                    {
                        Console.WriteLine(string.Format("Content of WordDefinition {0}", i));
                        Console.WriteLine();
                        Console.WriteLine(def.InnerXml);
                        Console.WriteLine();
                        definitions.Add(ParseWordDefinition(def.InnerXml));
                        foreach (Definition dd in definitions)
                        {
                            Console.WriteLine(string.Format("Parsed Word Definition for \"{0}\"", dd.wordDefined));
                            Console.WriteLine();
                            foreach (Def d in dd.Defs)
                            {
                                string type = string.Empty;
                                switch (d.type)
                                {
                                    case "a":
                                        type = "Adjective";
                                        break;
                                    case "n":
                                        type = "Noun";
                                        break;
                                    case "v":
                                        type = "Verb";
                                        break;
                                    default:
                                        type = "";
                                        break;
                                }
                                Console.WriteLine(string.Format("Type \"{0}\"", type));
                                Console.WriteLine();
                                Console.WriteLine(string.Format("\tDefinition \"{0}\"", d.text));
                                Console.WriteLine();
                                if (d.Synonym != null && d.Synonym.Count > 0)
                                {
                                    Console.WriteLine("\tSynonyms");
                                    foreach (string syn in d.Synonym)
                                        Console.WriteLine("\t\t" + syn);
                                }
                            }
                        }
                    }
                }
            }
            static string EmulateWebService()
            {
                string result = string.Empty;
                // The "definition.xml"file is a copy of the test data you provided.
                using (StreamReader reader = new StreamReader(@"c:\projects\definitiontest\definitiontest\definition.xml"))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
            static Definition ParseWordDefinition(string xmlDef)
            {
                // Replace any carriage return/line feed characters with spaces.
                string oneLine = xmlDef.Replace(System.Environment.NewLine, " ");
                // Squeeze internal white space.
                string squeezedLine = Regex.Replace(oneLine, @"\s{2,}", " ");
                // Assumption 1: The first word in the string is always the word being defined.
                string[] wordAndDefs = squeezedLine.Split(new char[] { ' ' }, StringSplitOptions.None);
                string wordDefined = wordAndDefs[0];
                string allDefinitions = string.Join(" ", wordAndDefs, 1, wordAndDefs.Length - 1);
                Definition parsedDefinition = new Definition();
                parsedDefinition.wordDefined = wordDefined;
                parsedDefinition.Defs = new List<Def>();
                string type = string.Empty;
                // Assumption 2: All definitions are delimited by a type letter, a number and a ':' character.
                string[] subDefinitions = Regex.Split(allDefinitions, @"(n|v|a){0,1}\s\d{1,}:");
                foreach (string definitionPart in subDefinitions)
                {
                    if (string.IsNullOrEmpty(definitionPart))
                        continue;
                    if (definitionPart == "n" || definitionPart == "v" || definitionPart == "a")
                    {
                        type = definitionPart;
                    }
                    else
                    {
                        Def def = new Def();
                        def.type = type;
                        // Assumption 3. Synonyms always use the [syn: {..},... ] pattern.
                        string realDef = (Regex.Split(definitionPart, @"\[\s*syn:"))[0];
                        def.text = realDef;
                        MatchCollection syns = Regex.Matches(definitionPart, @"\{([a-zA-Z\s]{1,})\}");
                        if (syns.Count > 0)
                            def.Synonym = new List<string>();
                        foreach (Match match in syns)
                        {
                            string s = match.Groups[0].Value;
                            // A little problem with regex retaining braces, so
                            // remove them here.
                            def.Synonym.Add(s.Replace('{', ' ').Replace('}', ' ').Trim());
                            int y = 0;
                        }
                        parsedDefinition.Defs.Add(def);
                    }
                }
                return parsedDefinition;
            }
        }
        public class Def
        {
            // Moved your type from Definition to Def, since it made more sense to me.
            public string type { get; set; } // single character: n or v or a 
            public string text { get; set; }
            // Changed your synonym definition here.
            public List<string> Synonym { get; set; }
        }
        public class Definition
        {
            public string wordDefined { get; set; }
            // Changed Def to Defs.
            public List<Def> Defs { get; set; }
        }
    }
