    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    namespace Test001
    {
        public class Dialogs
        {
            private static string DEFAULT_DATA =
                "<Phrases>" +
                    "<Phrase Role=\"2\">Example 1</Phrase>" +
                    "<Phrase Role=\"2\">Example 2</Phrase>" +
                    "<Phrase Role=\"1\">Example 3</Phrase>" +
                    "<Phrase Role=\"1\">Example 4</Phrase>" +
                    "<Phrase Role=\"2\">Example 5</Phrase>" +
                    "<Phrase Role=\"1\">Example 6</Phrase>" +
                    "<Phrase Role=\"2\">Example 7</Phrase>" +
                "</Phrases>"
            ;
    
            private int nextID;
    
            private Dictionary<string, Phrase> Phrases = new Dictionary<string, Phrase>();
    
            public List<Phrase> PhrasesList
            {
                get
                {
                    return this.Phrases.Values.ToList();
                }
            }
    
    
            public Dialogs()
            {
                this.Phrases = new Dictionary<string, Phrase>();
                this.nextID = 0;
            }
    
            public bool Load(string filename = null)
            {
                this.Phrases.Clear();
                this.nextID = 0;
                XmlDocument doc = new XmlDocument();
                try
                {
                    if (filename == null)
                    {
                        doc.LoadXml(DEFAULT_DATA);
                    }
                    else
                    {
                        doc.Load(filename);
                    }
                }
                catch
                {
                    // Error loading data
                    return false;
                }
    
                // Get all the phrases
                XmlNodeList phrases = doc.GetElementsByTagName("Phrase");
                foreach (XmlNode phraseNode in phrases)
                {
                    Phrase phrase = NodeToPhrase(phraseNode);
                    this.Add(phrase);
                }
    
                return true;
            }
    
            public void Add(Phrase phrase)
            {
                this.Phrases.Add(this.nextID.ToString(), phrase);
                this.nextID++;
            }
    
            // Parse a xml node to a phrase
            private Phrase NodeToPhrase(XmlNode node)
            {
                Phrase phrase = new Phrase();
                XmlNode roleNode = node.Attributes["Role"];
                if (roleNode != null && !string.IsNullOrEmpty(roleNode.Value))
                {
                    phrase.Role = roleNode.Value;
                    phrase.PhraseID = this.nextID.ToString();
                    if (node.HasChildNodes)
                    {
                        phrase.Text = node.FirstChild.Value;
                    }
                    this.nextID++;
                }
    
                return phrase;
            }
        }
    }
