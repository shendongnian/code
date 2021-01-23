    using System;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    
    namespace Sandbox2
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                var now = new Moment () { Timestamp = DateTime.Now };
                var xs = new XmlSerializer (typeof(Moment));
                xs.Serialize (Console.Out, now);
            }
        }
    
        public class Moment
        {
            const string FracSecPatt = @"\d\d\.\d*";
    
            static readonly MatchEvaluator DropFrac =
                m => double.Parse (m.Value).ToString ("00");
    
            [XmlElement("Timestamp")]
            public string _Timestamp;
    
            [XmlIgnore]
            public DateTime Timestamp
            {
                get
                {
                    return DateTime.Parse (_Timestamp);
                }
                set
                {
                    _Timestamp = Regex.Replace
                        (value.ToString ("O"), FracSecPatt, DropFrac);
                }
            }
        }
    }
